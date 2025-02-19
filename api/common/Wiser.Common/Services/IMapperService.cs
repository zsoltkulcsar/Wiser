namespace Wiser.Common.Services
{
    public interface IMapperService<TSource, TResult>
        where TSource : class
        where TResult : class
    {
        Task<TResult> MapAsync(TSource source, CancellationToken cancellationToken = default);
    }
}
