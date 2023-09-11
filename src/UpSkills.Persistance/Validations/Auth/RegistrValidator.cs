using FluentValidation;
using UpSkills.Persistance.Dto.Auth;

namespace UpSkills.Persistance.Validations.Auth;

public class RegistrValidator : AbstractValidator<RegistrDto>
{
    public RegistrValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required !")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters").MinimumLength(3)
            .WithMessage("Firstname must be more than 3 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required !")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters").MinimumLength(3)
            .WithMessage("Lastname must be more than 3 characters");

        RuleFor(dto => dto.Email).Must(email => EmailValidations.IsValid(email))
            .WithMessage("Email addres is invalid! example@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}