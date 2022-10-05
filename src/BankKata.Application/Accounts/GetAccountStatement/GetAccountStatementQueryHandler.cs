using BankKata.Application.Shared.Handlers;
using BankKata.Domain.Accounts;

namespace BankKata.Application.Accounts.GetAccountStatement;

public sealed class GetAccountStatementQueryHandler : IQueryHandler<GetAccountStatementQuery, AccountStatementDto>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountStatementQueryHandler(IAccountRepository accountRepository)
        => _accountRepository = accountRepository;

    public async Task<AccountStatementDto> Handle(GetAccountStatementQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByIdAsync(request.AccountId);

        if (account.IsDefault())
        {
            return new AccountStatementDto();
        }

        var statements = account
            .Transactions
            .OrderByDescending(t => t.ExecutedAt)
            .Select(t => new Statement
            {
                Date = t.ExecutedAt,
                Credit = t.Credit(),
                Debit = t.Debit()
            })
            .ToList();

        return new AccountStatementDto
        {
            AccountId = account.Id,
            Statements = statements
        };
    }
}