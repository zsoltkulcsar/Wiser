using MediatR;

namespace Wiser.Common.Requests
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}
