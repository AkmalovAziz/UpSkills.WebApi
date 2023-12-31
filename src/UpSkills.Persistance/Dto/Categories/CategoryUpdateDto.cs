﻿using Microsoft.AspNetCore.Http;

namespace UpSkills.Persistance.Dto.Categories;

public class CategoryUpdateDto
{
    public string CategoryName { get; set; } = string.Empty;
    public IFormFile? ImagePath { get; set; }
    public string Description { get; set; } = string.Empty;
}