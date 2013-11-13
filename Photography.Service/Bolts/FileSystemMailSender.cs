using System.IO;
using Photography.Core.Contracts.Service;

namespace Photography.Service.Bolts
{
    public class FileSystemMailSender : IMailService
    {
        private readonly IConfiguration _configuration;

        public FileSystemMailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendEmail(string @from, string to, string subject, string body)
        {
            var directory = _configuration.EmailDirectory;
            if (!Directory.Exists(directory))
            {
                var directoryInfo = Directory.CreateDirectory(directory);
                directory = directoryInfo.Name;
            }

            var path = Path.Combine(directory, subject + ".txt");

            
            using (var file = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
            {
                file.WriteLine("From: {0}", @from);
                file.WriteLine(string.Empty);
                file.WriteLine("To: {0}", to);
                file.WriteLine(string.Empty);
                file.WriteLine("Subject: {0}", subject);
                file.WriteLine(string.Empty);
                file.WriteLine(body);
            }

            return true;
        }
    }
}
