using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("felipe@fujihara.com", "Felipe Fujihara");
            var subject = "SendGrid Test";
            var to = new EmailAddress("felipe.fujihara@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
