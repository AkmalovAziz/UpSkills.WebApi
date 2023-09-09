namespace UpSkills.Domain.Entities.Categories;

public class Category : AudiTable
{
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}