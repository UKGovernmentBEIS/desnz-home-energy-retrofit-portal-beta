using System.Collections.Generic;
using HerPortal.BusinessLogic.Models;
using HerPortal.ManagementShell;
using Moq;
using NUnit.Framework;
using Tests.Builders;

namespace Tests.ManagementShell;

public class AdminActionTests
{
    private Mock<IOutputProvider> mockOutputProvider;
    private Mock<IDatabaseOperation> mockDatabaseOperation;
    private AdminAction underTest;
    
    [SetUp]
    public void Setup()
    {
        mockOutputProvider = new Mock<IOutputProvider>();
        mockDatabaseOperation = new Mock<IDatabaseOperation>();
        underTest = new AdminAction(mockDatabaseOperation.Object, mockOutputProvider.Object);
    }

    [Test]
    public void FindsExistingUserCaseInsensitively_IfInDatabase()
    {
        // Arrange
        var users = new List<User>
        {
            new UserBuilder("existinguser@email.com").Build(),
            new UserBuilder("existinguser2@email.com").Build()
        };
        const string userEmailAddress = "ExistingUser@email.com";
        mockDatabaseOperation.Setup(db => db.GetUsersWithLocalAuthorities()).Returns(users);
        
        // Act
        var returnedUser = underTest.GetUser(userEmailAddress);
        
        // Assert
        Assert.AreEqual(users[0].EmailAddress, returnedUser!.EmailAddress);
    }

    private void SetupConfirmCustodianCodes(IEnumerable<string> custodianCodes, string userEmailAddress)
    {
        mockOutputProvider
            .Setup(op =>
                op.Output(
                    $"You are changing permissions for user {userEmailAddress} for the following local authorities: "));
        foreach (var code in custodianCodes)
        {
            mockOutputProvider.Setup(op => op.Output("Code: Local Authority"));
        }

        mockOutputProvider.Setup(op => op.Confirm("Please confirm")).Returns(true);
    }

    // private MockSequence SetupUserResponses(params string[] userResponses)
    // {
    //     var sequence = new MockSequence();
    //     foreach (var response in userResponses)
    //     {
    //         mockConsoleInput.InSequence(sequence).Setup(textReader => textReader.ReadLine()).Returns(response);
    //     }
    //     return sequence;
    // }
}