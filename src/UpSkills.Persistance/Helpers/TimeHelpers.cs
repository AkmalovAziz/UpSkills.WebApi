using UpSkills.Domain.Constans;

namespace UpSkills.Persistance.Helpers;

public class TimeHelpers
{
    public static DateTime GetDateTime()
    {
        var datetime = DateTime.UtcNow;
        datetime.AddHours(TimeConstans.UTC);

        return datetime;
    }
}