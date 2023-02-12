using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBikeStoresAPI.Helpers
{
    public static class EmailHelper
    {
        private static readonly string _apiKey = "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";
        private static readonly string _senderEmail = "support@code-mega.com";//email dang ky sendgrid
        private static readonly string _senderName = "Duc Huy";
        public static async Task SendAsync(string sender, string message)
        {
            var emailContent = $"<p>Dear Admin, <br/> " +
                $"The client with email address {sender} have sent a message with content: <br/> " +
                $"<strong>{message}</strong> </p>";

            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_senderEmail, _senderName);
            var tos = new List<EmailAddress>()
            {
                new EmailAddress("duchuyy16@gmail.com", "")
            };
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, "Test Send Mail", "", emailContent);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine(response.StatusCode.ToString());
        }
    }
}
