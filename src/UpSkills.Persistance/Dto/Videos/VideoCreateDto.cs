using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Videos;

public class VideoCreateDto
{
    public string Description { get; set; } = string.Empty;
    public IFormFile ImagePath { get; set; } = default!;
}