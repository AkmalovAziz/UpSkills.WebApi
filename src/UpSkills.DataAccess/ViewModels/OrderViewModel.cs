using UpSkills.Domain.Entities;

namespace UpSkills.DataAccess.ViewModels;

public class OrderViewModel : AudiTable
{
    public long CourseId { get; set; }
    public long UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public float PricePerMonth { get; set; }
    public DateTime CreatedAt { get; set; }
}