namespace UpSkills.Persistance.Dto.Auth;

public class VerifyDto
{
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}