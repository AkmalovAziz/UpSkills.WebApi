﻿using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using UpSkills.Persistance.Dto.Notifications;
using UpSkills.Service.Interfaces.Notifications;

namespace UpSkills.Service.Service.Notifications;

public class EmailSMSSender : IEmailSMSSender
{
    private readonly string SENDER_EMAIL = string.Empty;
    private readonly string PLATFORM = string.Empty;
    private readonly string PASSWORD = string.Empty;
    private readonly int PORT;
    public EmailSMSSender(IConfiguration configuration)
    {
        SENDER_EMAIL = configuration["Email:SenderEmail"]!;
        PLATFORM = configuration["Email:Platform"]!;
        PASSWORD = configuration["Email:Password"]!;
        PORT = int.Parse(configuration["Email:Port"]!);
    }
    public async Task<bool> SendAsync(SmsMessage emailMessage)
    {
        try
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(SENDER_EMAIL));
            mail.To.Add(MailboxAddress.Parse(emailMessage.Resipient));
            mail.Subject = emailMessage.Title;
            mail.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content.ToString()
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(PLATFORM, PORT, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(SENDER_EMAIL, PASSWORD);
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);

            return true;
        }
        catch
        {
            return false;
        }
    }
}