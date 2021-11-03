using Qitar.Dependencies;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IResolveHandler _resolveHandler;

        private static readonly ConcurrentDictionary<Type, object> _queryHandlers = new ConcurrentDictionary<Type, object>();

        public QueryProcessor(IResolveHandler resolveHandler)
        {
            _resolveHandler = resolveHandler ?? throw new ArgumentNullException(nameof(resolveHandler));
        }

        public ValueTask<TResult> Process<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var queryType = query.GetType();

            var handler = (BaseQueryHandlerWrapper<TResult>)_queryHandlers.GetOrAdd(queryType,
                t => Activator.CreateInstance(typeof(QueryHandlerWrapper<,>).MakeGenericType(t, typeof(TResult))
               ?? throw new InvalidOperationException($"Could not create wrapper type for {t}")));

            return handler.Handle(query, _resolveHandler,cancellationToken);
        }
    }
}