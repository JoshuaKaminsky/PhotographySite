namespace Photography.Core.Contracts.Process
{
    public interface IRoleProcess : IProcess
    {
        bool IsInRole(int userId, string roleName);
    }
}