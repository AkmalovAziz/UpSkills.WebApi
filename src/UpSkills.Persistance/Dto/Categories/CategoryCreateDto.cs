using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Categories;
public class CategoryCreateDto
{
    public string Name { get; set; } = string.Empty;
    public IFormFile ImagePath { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
}