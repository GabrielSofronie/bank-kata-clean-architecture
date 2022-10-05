namespace BankKata.Domain.Accounts;

public record Transaction(decimal Amount, DateTime ExecutedAt)
{
    public static Transaction Create(decimal amount, DateTime dateTime)
    {
        return new(amount, dateTime);
    }

    public decimal Credit() => Amount > 0 ? Amount : 0;
    public decimal Debit() => Amount > 0 ? 0 : Amount * -1;
}