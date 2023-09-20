using FluentValidation;
using UpSkills.Persistance.Dto.Categories;
using UpSkills.Persistance.Helpers;

namespace UpSkills.Persistance.Validations.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        int MaxImageSizeMB = 5;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");

        RuleFor(dto => dto.ImagePath.Length).LessThan(MaxImageSizeMB * 1024 * 1024)
            .WithMessage($"Image size must be less than {MaxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            var fileinfo = new FileInfo(predicate);

            return MediaHelpers.GetImageExtension().Contains(fileinfo.Extension);
        }).WithMessage("This file type isn't image file");

        RuleFor(dto => dto.CategoryName).NotNull().NotEmpty().WithMessage("Name is required !")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(30).WithMessage("Name must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");
    }
}