using BankKata.Application.Shared.Contracts;
using MediatR;

namespace BankKata.Application.Shared.Handlers;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
{
}