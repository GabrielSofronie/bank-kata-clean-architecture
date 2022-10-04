using BankKata.Api.IntegrationTests.Shared;
using BankKata.Application.Accounts.GetAccountStatement;
using Newtonsoft.Json;

namespace BankKata.Api.IntegrationTests.Controllers.Accounts;

public class StatementTests : IClassFixture<TestBase>
{
    private readonly TestBase _testBase;

    public StatementTests(TestBase testBase)
    {
        _testBase = testBase;
    }

    [Fact]
    public async Task ReturnsAllTransactionsInDescendingOrder()
    {
        var id = Guid.NewGuid();
        var response = await _testBase.Client().GetAsync($"/api/accounts/{id}/statement");

        response.EnsureSuccessStatusCode();

        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AccountStatementDto>(stringResult);

        Assert.Equal(id, result.AccountId);
        Assert.Equal(500, result.Statements.ElementAt(0).Debit);
        Assert.Equal(2000, result.Statements.ElementAt(1).Credit);
        Assert.Equal(1000, result.Statements.ElementAt(2).Credit);
    }
}