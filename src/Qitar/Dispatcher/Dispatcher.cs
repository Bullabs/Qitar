using Qitar.Objects.Results;
using Qitar.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryProcessor _queryProcessor;

        public Dispatcher(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor ?? throw new ArgumentNullException(nameof(queryProcessor));
        }

        public async ValueTask<TResult> GetResult<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult> where TResult : IResult
        {
            return await _queryProcessor.Process<TQuery, TResult>(query, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TResult> GetResult<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : IResult
        {
            return await _queryProcessor.Process<IQuery<TResult>,TResult>(query, cancellationToken).ConfigureAwait(false);
        }
    }
}
