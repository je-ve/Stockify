using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Stockify.Objects;

public class EmailService : IEmailService
{
    private readonly string _fromEmail = "verstraete.jens@gmail.com";
    private readonly string _appPassword = "leur qbws hhaj kvow"; // no spaces

    private readonly SmtpClient _smtpClient;
    public EmailService()
    {
        _smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_fromEmail, _appPassword)
        };
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var message = new MailMessage(_fromEmail, to, subject, body)
        {
            IsBodyHtml = true
        };

        await _smtpClient.SendMailAsync(message);
    }

    //  public async Task SendEmailWithAttachmentAsync(string to, string subject, string htmlBody,  string attachmentName)
    public async Task SendEmailWithAttachmentAsync(Order order)
    {
        byte[] pdfData = PdfGenerator.GenerateDeliveryPdf(order); // Replace with actual data

        string htmlBody = $@"
            <h1>Bestelling {order.Id} geleverd</h1>
            <p>Beste {order.Customer.Name},</p>
            <p>Uw bestelling is afgeleverd.</p>
            <p>Bedankt voor uw bestelling!</p>";

        var message = new MailMessage(_fromEmail, order.Customer.Email, $"Stockify bestelling {order.Id} geleverd", htmlBody)
        {
            IsBodyHtml = true
        };

        // Add PDF attachment
        using var pdfStream = new MemoryStream(pdfData);
        var attachment = new Attachment(pdfStream, "overzicht.pdf", MediaTypeNames.Application.Pdf);
        message.Attachments.Add(attachment);

        await _smtpClient.SendMailAsync(message);
    }
}
