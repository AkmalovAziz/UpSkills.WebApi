namespace UpSkills.Domain.Entities.Videos;

public class Video : AudiTable
{
    public long CourseId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}