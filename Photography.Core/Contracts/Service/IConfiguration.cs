namespace Photography.Core.Contracts.Service
{
    public interface IConfiguration
    {
        string EmailDirectory { get; }

        int PasswordResetRequestTimeoutInMinutes { get; }
    }
}