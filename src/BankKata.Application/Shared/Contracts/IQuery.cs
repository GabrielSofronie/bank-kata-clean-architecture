using MediatR;

namespace BankKata.Application.Shared.Contracts;

public interface IQuery<out TResult> : IRequest<TResult> { }