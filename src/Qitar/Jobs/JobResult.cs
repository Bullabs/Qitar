using Qitar.Objects.Responses;
using System;

namespace Qitar.Jobs
{
    public class JobResult: IResponse
    {
        public bool IsCancelled { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
