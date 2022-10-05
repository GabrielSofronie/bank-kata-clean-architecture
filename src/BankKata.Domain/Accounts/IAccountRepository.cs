namespace BankKata.Domain.Accounts;

public interface IAccountRepository
{
    Task AddAsync(Account account);
    Task<Account> GetByIdAsync(Guid accountId);
}