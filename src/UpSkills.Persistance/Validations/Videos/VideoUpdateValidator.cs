using FluentValidation;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Helpers;

namespace UpSkills.Persistance.Validations.Videos;

public class VideoUpdateValidator : AbstractValidator<VideoUpdateDto>
{
    public VideoUpdateValidator()
    {
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");

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