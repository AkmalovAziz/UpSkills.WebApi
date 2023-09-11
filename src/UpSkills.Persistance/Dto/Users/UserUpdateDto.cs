using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? ImagePath { get; set; }
    public string Description { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
}