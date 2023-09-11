using FluentValidation;
using UpSkills.Persistance.Dto.Categories;

namespace UpSkills.Persistance.Validations.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name is required !")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(30).WithMessage("Name must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");
    }
}