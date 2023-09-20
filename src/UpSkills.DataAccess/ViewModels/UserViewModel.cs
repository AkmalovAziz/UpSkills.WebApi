using UpSkills.Domain.Entities;

namespace UpSkills.DataAccess.ViewModels;

public class UserViewModel : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
}