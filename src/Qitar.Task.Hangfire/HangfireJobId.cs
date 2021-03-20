using Qitar.Jobs;
using Qitar.Objects;

namespace Qitar.Task.Hangfire
{
    public class HangfireJobId : IJobId, IIdentity<string>
    {
        public string Id { get; set; }

        object IIdentity.Id => Id;

        public HangfireJobId(string id)
        {
            Id = id;
        }
    }
}
