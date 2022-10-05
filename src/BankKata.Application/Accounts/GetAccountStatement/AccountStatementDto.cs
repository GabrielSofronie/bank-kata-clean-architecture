namespace BankKata.Application.Accounts.GetAccountStatement;

public sealed class AccountStatementDto
{
    public Guid AccountId { get; set; }
    public ICollection<Statement> Statements { get; set; } = new List<Statement> { };
}

public sealed class Statement
{
    public DateTime Date { get; set; }
    public decimal Credit { get; set; }
    public decimal Debit { get; set; }
}