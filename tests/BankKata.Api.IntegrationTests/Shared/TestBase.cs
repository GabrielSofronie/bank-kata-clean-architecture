using BankKata.Domain.Accounts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BankKata.Api.IntegrationTests.Shared;

public class TestBase : IDisposable
{
    private readonly TestApplicationFactory _factory = new();

    private readonly HttpClient _httpClient;

    private readonly Scenarios _scenarios;

    public TestBase()
    {
        _httpClient = _factory.CreateDefaultClient();

        var accountRepository = _factory.Services.GetService<IAccountRepository>() ?? throw new Exception();
        _scenarios = new Scenarios(accountRepository);
    }

    public HttpClient Client() => _httpClient;

    internal Scenarios Scenarios() => _scenarios;

    public void Dispose()
    {
        _httpClient.Dispose();
        _factory.Dispose();
    }

    class TestApplicationFactory : WebApplicationFactory<Program>
    {
    }
}