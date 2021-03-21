using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Objects.Responses
{
    public class BooleanResponse : IResponse
    {
        public bool IsSuccess { get; set; }
    }
}
