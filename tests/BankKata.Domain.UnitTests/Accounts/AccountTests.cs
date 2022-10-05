using BankKata.Domain.Accounts;

namespace BankKata.Domain.UnitTests.Accounts;

public class AccountTests
{
    [Fact]
    public void ShouldAddDepositTransaction()
    {
        var account = Account.Open();
        var amount = 1000;
        var depositTime = DateTime.UtcNow;

        account.Deposit(amount, depositTime);

        var transaction = account.Transactions.FirstOrDefault(t => t.Amount == amount && t.ExecutedAt == depositTime);

        Assert.NotNull(transaction);
    }

    [Fact]
    public void ShouldAddWithdrawTransaction()
    {
        var account = Account.Open();
        var amount = 500;
        var withdrawTime = DateTime.UtcNow;

        account.Withdraw(amount, withdrawTime);

        var transaction = account.Transactions.FirstOrDefault(t => t.Amount == -amount && t.ExecutedAt == withdrawTime);

        Assert.NotNull(transaction);
    }
}