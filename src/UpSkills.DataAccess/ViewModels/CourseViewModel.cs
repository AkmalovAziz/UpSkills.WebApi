using UpSkills.Domain.Entities;

namespace UpSkills.DataAccess.ViewModels;

public class CourseViewModel : AudiTable
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float PricePerMonth { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}