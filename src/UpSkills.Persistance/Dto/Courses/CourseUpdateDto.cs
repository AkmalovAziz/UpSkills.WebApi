using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Courses;

public class CourseUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float PricePerMonth { get; set; }
    public IFormFile? ImagePath { get; set; }
}