using BankKata.Domain.Accounts;

namespace BankKata.Api.IntegrationTests.Shared;

internal class Scenarios
{
    private readonly IAccountRepository _accountRepository;

    public Scenarios(IAccountRepository accountRepository) => _accountRepository = accountRepository;

    public async Task<Guid> AccountStatement()
    {
        var account = Account.Open();
        account.Deposit(1000, DateTime.UtcNow.AddDays(-2));
        account.Deposit(2000, DateTime.UtcNow.AddDays(-1));
        account.Withdraw(500, DateTime.UtcNow.AddMinutes(-5));

        await _accountRepository.AddAsync(account);

        return account.Id;
    }
}