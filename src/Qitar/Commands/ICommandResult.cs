using Qitar.Events;
using Qitar.Objects.Responses;
using System;
using System.Collections.Generic;

namespace Qitar.Commands
{
    public interface ICommandResult: IResult
    {
        public bool IsSuccessful { get;}
        public object Result { get; set; }
        public string Message { get; set; }
        public IEnumerable<IEvent> Events { get; set; }
        public Exception Exception { get; set; }
    }
}
