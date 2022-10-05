using BankKata.Application.Shared.Contracts;

namespace BankKata.Application.Accounts.GetAccountStatement;

public sealed class GetAccountStatementQuery : IQuery<AccountStatementDto>
{
    public GetAccountStatementQuery(Guid accountId)
    {
        AccountId = accountId;
    }

    public Guid AccountId { get; }
}