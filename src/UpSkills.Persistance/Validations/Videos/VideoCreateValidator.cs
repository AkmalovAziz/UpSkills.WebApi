using FluentValidation;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Helpers;

namespace UpSkills.Persistance.Validations.Videos;

public class VideoCreateValidator : AbstractValidator<VideoCreateDto>
{
    public VideoCreateValidator()
    {
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required !")
            .MinimumLength(10).WithMessage("Description must be more than 10 characters");

        int MaxImageSizeMB = 5;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");

        RuleFor(dto => dto.ImagePath.Length).LessThan(MaxImageSizeMB * 1024 * 1024)
            .WithMessage($"Image size must be less than {MaxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            var fileinfo = new FileInfo(predicate);

            return MediaHelpers.GetImageExtension().Contains(fileinfo.Extension);
        }).WithMessage("This file type isn't image file");
    }
}