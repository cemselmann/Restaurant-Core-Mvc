using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Restaurantt.Email
{
    public class EMailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
             
        {
            var client = new SendGridClient(Options.SendGridKey);
            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("lagajo1123@cnxcoin.com", "Mersin Restoran"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage

            };
            mesaj.AddTo(new EmailAddress(email));
            try
            {
                return client.SendEmailAsync(mesaj);    

            }
            catch (System.Exception)
            {

                throw;
            }
        
        }
        public EMailOptions Options { get; set; }
        public EMailSender(IOptions<EMailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }
    }
}
