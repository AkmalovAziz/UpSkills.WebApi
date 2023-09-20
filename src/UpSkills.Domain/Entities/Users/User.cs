using UpSkills.Domain.Enums;

namespace UpSkills.Domain.Entities.Users;

public class User : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Amount { get; set; }
    public string BirthDate { get; set; } = string.Empty;
    public UserStatusRoles Status { get; set; }
}