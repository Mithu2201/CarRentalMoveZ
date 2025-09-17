using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CarRentalMoveZ.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            using (var client = new SmtpClient(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"])))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(
                    emailSettings["Username"],
                    emailSettings["Password"]
                );

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
