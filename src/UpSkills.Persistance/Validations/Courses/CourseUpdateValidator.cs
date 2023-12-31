﻿using FluentValidation;
using UpSkills.Persistance.Dto.Courses;
using UpSkills.Persistance.Helpers;

namespace UpSkills.Persistance.Validations.Courses;

public class CourseUpdateValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required !")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(30).WithMessage("Name must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");

        int num = 0;
        RuleFor(dto => dto.PricePerMonth).Must(price => PriceValidator.IsValid(price))
            .WithMessage($"Price isn't less than {num}");

        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.ImagePath!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);

                return MediaHelpers.GetImageExtension().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}