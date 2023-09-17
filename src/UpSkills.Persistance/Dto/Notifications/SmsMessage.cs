namespace UpSkills.Persistance.Dto.Notifications;

public class SmsMessage
{
    public string Resipient { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}