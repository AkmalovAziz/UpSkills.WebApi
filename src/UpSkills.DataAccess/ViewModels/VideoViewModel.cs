namespace UpSkills.DataAccess.ViewModels;

public class VideoViewModel
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string VideoPath { get; set; } = string.Empty;
    public string VideoDescription { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}