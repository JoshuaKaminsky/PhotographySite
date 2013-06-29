namespace Photography.Core.Contracts.Process
{
    public interface IRoleProcess
    {
        bool IsInRole(int userId, string roleName);
    }
}