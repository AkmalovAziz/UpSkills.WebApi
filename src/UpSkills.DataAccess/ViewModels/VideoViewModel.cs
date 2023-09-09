namespace UpSkills.DataAccess.ViewModels;

public class VideoViewModel
{
    public long CourseId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}