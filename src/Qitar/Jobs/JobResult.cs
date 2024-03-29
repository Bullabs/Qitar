﻿using Qitar.Objects.Results;
using System;

namespace Qitar.Jobs
{
    public class JobResult: IResult
    {
        public bool IsCancelled { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
