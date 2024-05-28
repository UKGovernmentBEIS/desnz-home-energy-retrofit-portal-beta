using HerPortal.BusinessLogic.Models;

namespace HerPortal.ManagementShell;

public interface IDatabaseOperation
{
    public List<User> GetUsersWithLocalAuthoritiesAndConsortia();
    public List<LocalAuthority> GetLas(IEnumerable<string> custodianCodes);
    public List<Consortium> GetConsortia(IEnumerable<string> consortiumCodes);
    public void RemoveUserOrLogError(User user);
    public void CreateUserOrLogError(string userEmailAddress, List<LocalAuthority> localAuthorities, List<Consortium> consortia);
    public void AddLasToUser(User user, List<LocalAuthority> localAuthorities);
    public void AddConsortiaToUser(User user, List<Consortium> consortia);
    public void RemoveLasFromUser(User user, List<LocalAuthority> localAuthorities);
    public void AddConsortiaAndRemoveLasFromUser(User user, List<Consortium> consortia, List<LocalAuthority> localAuthorities);
}