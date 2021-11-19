using Qitar.Dependencies;
using Qitar.Objects.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    internal abstract class BaseQueryHandlerWrapper<TResult> where TResult : IResult
    {
        protected static THandler GetHandler<THandler>(IResolveHandler resolverHandler)
        {
            return resolverHandler.ResolveHandler<THandler>();
        }

        public abstract ValueTask<TResult> Handle(IQuery<TResult> query, IResolveHandler resolverHandler, CancellationToken cancellationToken = default);
    }

    internal class QueryHandlerWrapper<TQuery, TResult> : BaseQueryHandlerWrapper<TResult> where TQuery : IQuery<TResult> where TResult : IResult
    {
        public override ValueTask<TResult> Handle(IQuery<TResult> query, IResolveHandler resolverHandler, CancellationToken cancellationToken = default)
        {
            var handler = GetHandler<IQueryHandler<TQuery, TResult>>(resolverHandler);
            return handler.Handle((TQuery)query,cancellationToken);
        }
    }
}