namespace UpSkills.Domain.Entities.Courses;

public class Course : AudiTable
{
    public long CategoryId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float PricePerMonth { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}