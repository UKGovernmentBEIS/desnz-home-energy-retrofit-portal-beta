using HerPortal.BusinessLogic;
using HerPortal.BusinessLogic.Models;
using HerPortal.BusinessLogic.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HerPortal.Data;

public class DataAccessProvider : IDataAccessProvider
{
    private readonly HerDbContext context;

    public DataAccessProvider(HerDbContext context)
    {
        this.context = context;
    }

    public async Task<User> GetUserByEmailAsync(string emailAddress)
    {
        var users = await context.Users
            .Include(u => u.LocalAuthorities)
            // In order to compare email addresses case-insensitively, we bring the whole table into memory here
            //   to perform the comparison in C#, since Entity Framework doesn't allow for the StringComparison
            //   overload. However, since we don't expect this table to be monstrously huge this is acceptable
            //   in order to easily allow case-insensitive email addresses.
            .ToListAsync();
        return users
            .Single(u => string.Equals
                (
                    u.EmailAddress,
                    emailAddress,
                    StringComparison.CurrentCultureIgnoreCase
                ));
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await context.Users
            .Include(u => u.LocalAuthorities)
            .SingleAsync(user => user.Id == id);
    }

    public async Task MarkUserAsHavingLoggedInAsync(int userId)
    {
        var user = await context.Users
            .SingleAsync(u => u.Id == userId);

        user.HasLoggedIn = true;
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllActiveUsersAsync()
    {
        return await context.Users
            .Where(u => u.HasLoggedIn)
            .Include(u => u.LocalAuthorities)
            .ToListAsync();
    }

    public async Task AddUserByEmailAsync(string emailAddress)
    {
        await context.Users.AddAsync(new User
        {
            EmailAddress = emailAddress,
            HasLoggedIn = false
        });

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users
            .ToListAsync();
    }

    public async Task<List<CsvFileDownload>> GetCsvFileDownloadDataForUserAsync(int userId)
    {
        return await context.CsvFileDownloads.Where(cfd => cfd.UserId == userId).ToListAsync();
    }

    public async Task MarkCsvFileAsDownloadedAsync(string custodianCode, int year, int month, int userId)
    {
        User user;
        try
        {
            user = await context.Users.SingleAsync(u => u.Id == userId);
        }
        catch (InvalidOperationException ex)
        {
            throw new ArgumentOutOfRangeException($"No user found with ID {userId}", ex);
        }
        
        CsvFileDownload download;
        try
        {
            download = await context.CsvFileDownloads
                .SingleAsync(cfd =>
                    cfd.CustodianCode == custodianCode &&
                    cfd.Year == year &&
                    cfd.Month == month &&
                    cfd.UserId == userId
                );
        }
        catch (InvalidOperationException)
        {
            download = new CsvFileDownload
            {
                CustodianCode = custodianCode,
                Year = year,
                Month = month,
                UserId = userId,
            };
            await context.CsvFileDownloads.AddAsync(download);
        }

        download.LastDownloaded = DateTime.Now;

        var auditDownload = new AuditDownload
        {
            CustodianCode = custodianCode,
            Year = year,
            Month = month,
            UserEmail = user.EmailAddress,
            Timestamp = DateTime.Now,
        };
        await context.AuditDownloads.AddAsync(auditDownload);
        
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<LocalAuthority>> GetAllLocalAuthoritiesAsync()
    {
        return await context.LocalAuthorities.ToListAsync();
    }

    public async Task<LocalAuthority> GetLocalAuthorityByIdAsync(int id)
    {
        return await context.LocalAuthorities
            .SingleAsync(la => la.Id == id);
    }

    public async Task SetLocalAuthorityStatusById(int id, LocalAuthorityStatus status)
    {
        var localAuthority = await context
            .LocalAuthorities
            .SingleAsync(la => la.Id == id);

        localAuthority.Status = status;

        await context.SaveChangesAsync();
    }

    public async Task SetUserLocalAuthoritiesByIdAsync(int userId, List<int> localAuthorityIds)
    {
        var user = await GetUserByIdAsync(userId);
        var localAuthorities = context.LocalAuthorities.Where(la => localAuthorityIds.Contains(la.Id));

        user.LocalAuthorities = localAuthorities.ToList();

        await context.SaveChangesAsync();
    }
}
