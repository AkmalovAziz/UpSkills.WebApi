using FluentValidation;
using UpSkills.Persistance.Dto.Categories;

namespace UpSkills.Persistance.Validations.Categories;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");
    }
}