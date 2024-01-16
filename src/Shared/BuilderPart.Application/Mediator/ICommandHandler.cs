using MediatR;

namespace BuilderPart.Application.Mediator
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
