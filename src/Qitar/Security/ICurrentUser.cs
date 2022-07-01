namespace Qitar.Security
{
    public interface ICurrentUser: IUser
    {
        bool IsAuthenticated { get; }
    }
}
