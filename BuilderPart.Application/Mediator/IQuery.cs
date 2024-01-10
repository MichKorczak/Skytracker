using MediatR;

namespace BuilderPart.Application.Mediator;

public interface IQuery<out TResult> : IRequest<TResult>
{
}