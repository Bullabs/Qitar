using Qitar.Events;
using System;
using System.Collections.Generic;

namespace Qitar.Commands
{
    public record CommandResult: ICommandResult
    {
        public bool IsSuccessful
        {
            get { return Exception == null; }
        }
        public object Result { get; set; }
        public string Message { get; set; }
        public IEnumerable<IEvent> Events { get; set; } 
        public Exception Exception { get; set; }

        public CommandResult()
        {
        }

        public CommandResult(object result)
        {
           Result = result;
        }

        public CommandResult(object result,IEvent @event) : this(result)
        {
            Events = new List<IEvent>()
            {
                @event
            };
        }

        public CommandResult(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }
    }
}