using System;

namespace Qitar.Objects.Responses
{
    public interface IResponse
    {
        bool IsSuccess { get; }
    }
}
