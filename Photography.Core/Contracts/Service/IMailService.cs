namespace Photography.Core.Contracts.Service
{
    public interface IMailService
    {
        /// <summary>
        /// Send an email message
        /// </summary>
        /// <param name="from"> The sender address </param>
        /// <param name="to"> The recipient address </param>
        /// <param name="subject"> The message subject </param>
        /// <param name="body">The body of the message </param>
        /// <returns> True if successful </returns>
        bool SendEmail(string from, string to, string subject, string body);
    }
}