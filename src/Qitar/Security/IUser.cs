using System;

namespace Qitar.Security
{
    public interface IUser
    {
        Guid Id { get; }
        string UserName { get; }
        string? Email { get; }
        string[] Roles { get; }
    }
}
