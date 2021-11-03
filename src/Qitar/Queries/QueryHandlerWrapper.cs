using Qitar.Dependencies;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    internal abstract class BaseQueryHandlerWrapper<TResult>
    {
        protected static THandler GetHandler<THandler>(IResolveHandler resolverHandler)
        {
            return resolverHandler.ResolveHandler<THandler>();
        }

        public abstract ValueTask<TResult> Handle(IQuery<TResult> query, IResolveHandler resolverHandler, CancellationToken cancellationToken = default);
    }

    internal class QueryHandlerWrapper<TQuery, TResult> : BaseQueryHandlerWrapper<TResult> where TQuery : IQuery<TResult>
    {
        public override ValueTask<TResult> Handle(IQuery<TResult> query, IResolveHandler resolverHandler, CancellationToken cancellationToken = default)
        {
            var handler = GetHandler<IQueryHandler<TQuery, TResult>>(resolverHandler);
            return handler.Handle((TQuery)query,cancellationToken);
        }
    }
}