namespace BankKata.Domain.Accounts;

public sealed class Account
{
    public Guid Id { get; }
    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    private readonly List<Transaction> _transactions = new();

    private Account(Guid id) => Id = id;

    public static Account Open() => new(Guid.NewGuid());

    public static Account Default() => new(Guid.Empty);

    public void Deposit(decimal amount, DateTime depositedAt)
    {
        var transaction = Transaction.Create(amount, depositedAt);
        _transactions.Add(transaction);
    }

    public void Withdraw(decimal amount, DateTime withdrawnAt)
    {
        var transaction = Transaction.Create(-amount, withdrawnAt);
        _transactions.Add(transaction);
    }

    public bool IsDefault() => Id.Equals(Guid.Empty);
}