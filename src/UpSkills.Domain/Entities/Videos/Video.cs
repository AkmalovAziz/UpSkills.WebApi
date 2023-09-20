namespace UpSkills.Domain.Entities.Videos;

public class Video : BaseEntitiy
{
    public long CourseId { get; set; }
    public string VideoDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string VideoPath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}