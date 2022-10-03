using Microsoft.AspNetCore.Mvc.Testing;

namespace BankKata.Api.IntegrationTests.Shared;

public class TestBase
{
    private readonly TestApplicationFactory _factory = new();

    private readonly HttpClient _httpClient;

    public TestBase()
    {
        _httpClient = _factory.CreateDefaultClient();
    }

    public HttpClient Client() => _httpClient;

    class TestApplicationFactory : WebApplicationFactory<Program>
    {
    }
}