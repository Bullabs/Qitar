using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Objects.Responses
{
    public class BooleanResult : IResult
    {
        public bool IsSuccess { get; set; }
    }
}
