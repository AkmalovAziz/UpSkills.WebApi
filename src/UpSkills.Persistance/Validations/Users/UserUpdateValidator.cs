using FluentValidation;
using UpSkills.Persistance.Dto.Users;
using UpSkills.Persistance.Helpers;

namespace UpSkills.Persistance.Validations.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname field is required !")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname field is required !")
            .MinimumLength(3).WithMessage("Lastname must be more than 3 characters")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phonenumber field is required !");

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

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required !")
            .MinimumLength(20).WithMessage("Name must be more than 20 characters");

        RuleFor(dto => dto.BirthDate).Must(date => BirthDateValidator.IsValidBirthDate(date).IsValid)
            .WithMessage("The date of birth was entered incorrectly !");
    }
}