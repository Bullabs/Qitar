using Qitar.Queries;

using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryProcessor _queryProcessor;
        public Dispatcher(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public async ValueTask<TResult> GetResult<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult>
        {
            return await _queryProcessor.Process<TQuery, TResult>(query, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TResult> GetResult<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            return await _queryProcessor.Process<IQuery<TResult>,TResult>(query, cancellationToken).ConfigureAwait(false);
        }
    }
}
