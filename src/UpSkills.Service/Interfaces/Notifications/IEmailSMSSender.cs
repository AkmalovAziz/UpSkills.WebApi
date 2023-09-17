using UpSkills.Persistance.Dto.Notifications;

namespace UpSkills.Service.Interfaces.Notifications;

public interface IEmailSMSSender
{
    public Task<bool> SendAsync(SmsMessage smSMessage);
}