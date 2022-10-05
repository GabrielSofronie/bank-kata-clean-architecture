using BankKata.Domain.Accounts;

namespace BankKata.Infrastructure;
public class AccountRepository : IAccountRepository
{
    private readonly IDictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();

    public Task AddAsync(Account account)
    {
        _accounts[account.Id] = account;
        return Task.CompletedTask;
    }

    public Task<Account> GetByIdAsync(Guid accountId)
    {
        if (_accounts.TryGetValue(accountId, out var account))
        {
            return Task.FromResult(account);
        }

        return Task.FromResult(Account.Default());
    }
}
