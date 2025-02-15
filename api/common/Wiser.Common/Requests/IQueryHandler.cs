using MediatR;

namespace Wiser.Common.Requests
{
    public interface IQueryHandler<in TQuery, TResponse>
            : IRequestHandler<TQuery, TResponse>
            where TQuery : IQuery<TResponse>
            where TResponse : notnull
    {
    }
}
