using BankKata.Application.Accounts.GetAccountStatement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankKata.Api.Controllers.Accounts;

[ApiController]
[Route("/api/accounts")]
public class StatementController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatementController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}/statement")]
    public async Task<IActionResult> Get(Guid id)
    {
        var request = new GetAccountStatementQuery(id);
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}