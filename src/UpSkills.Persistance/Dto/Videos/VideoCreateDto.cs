using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Videos;

public class VideoCreateDto
{
    public long CourseId { get; set; }
    public string VideoDescription { get; set; } = string.Empty;
    public IFormFile ImagePath { get; set; } = default!;
    public IFormFile VideoPath { get; set; } = default!;
}