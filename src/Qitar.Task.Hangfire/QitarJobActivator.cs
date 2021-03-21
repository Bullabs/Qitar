using Hangfire;
using Qitar.Dependencies;
using System;

namespace Qitar.Task.Hangfire
{
    public class QitarJobActivator : JobActivator
    {
        private readonly IResolver _resolver;
        public QitarJobActivator(IResolver resolver)
        {
            _resolver = resolver;
        }

        public override object ActivateJob(Type jobType)
        {
            return _resolver.Resolve(jobType);
        }
    }
}
