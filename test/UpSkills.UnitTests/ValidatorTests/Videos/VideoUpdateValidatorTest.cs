using Microsoft.AspNetCore.Http;
using System.Text;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Validations.Videos;
using Xunit;

namespace UpSkills.UnitTests.ValidatorTests.Videos;

public class VideoUpdateValidatorTest
{
    [Theory]
    [InlineData("bjvbfhbv")]
    [InlineData("bjvbfh cd")]
    public void ShouldReturnWrongDescription(string description)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoUpdateDto();

        dto.Description = description;
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("bjvbfhbv nvdsjbvhjsdbjh bsdjbjh")]
    [InlineData("bjvbfh cdd jjds 5464545454")]
    public void ShouldReturnValidDescription(string description)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoUpdateDto();

        dto.Description = description;
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    public void ShouldReturnWrongImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024 + 1);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new VideoUpdateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(2.5)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3.4)]
    [InlineData(4.5)]
    public void ShouldReturnValidImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new VideoUpdateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.zip")]
    [InlineData("file.mp3")]
    [InlineData("file.mp4")]
    [InlineData("file.avi")]
    [InlineData("file.pgred")]
    [InlineData("file.html")]
    [InlineData("file.cs")]
    [InlineData("file.sln")]
    public void ShouldReturnWrongImageExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new VideoUpdateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("file.bmp")]
    [InlineData("file.jpg")]
    [InlineData("file.png")]
    [InlineData("file.jpeg")]
    [InlineData("file.svg")]
    public void ShouldReturnValidImageExtension(string imagename)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new VideoUpdateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;

        var validator = new VideoUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}