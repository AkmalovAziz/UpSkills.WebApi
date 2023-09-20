using Microsoft.AspNetCore.Http;
using System.Text;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Validations.Videos;
using Xunit;

namespace UpSkills.UnitTests.ValidatorTests.Videos;

public class VideoCreateValidatorTest
{
    [Theory]
    [InlineData("bjvbfhbv")]
    [InlineData("jvbfh cdd")]
    public void ShouldReturnWrongDescription(string description)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = description;
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("bjvbfhbv nvdsjbvhjsdbjh bsdjbjh")]
    [InlineData("bjvbfh cdd jjds 5464545454")]
    public void ShouldReturnValidDescription(string description)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = description;
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(5.5)]
    [InlineData(15.5)]
    [InlineData(10)]
    [InlineData(8)]
    [InlineData(5.2)]
    public void ShouldReturnWrongImageSize(float MaxImageSizeMB)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024 + 1);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
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
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
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
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
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
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(1025.5)]
    [InlineData(830.9)]
    [InlineData(1000)]
    [InlineData(2500)]
    [InlineData(680)]
    [InlineData(368.98)]
    public void ShouldReturnWrongVideoSize(float MaxVideoSizeMB)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long videoSizeInBytes = (long)(MaxVideoSizeMB * 1024 * 1024 + 1);
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, videoSizeInBytes, "data", "file.mp4");

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(120.5)]
    [InlineData(80)]
    [InlineData(92)]
    [InlineData(83.4)]
    [InlineData(254.5)]
    public void ShouldReturnValidVideoSize(float MaxVideoSizeMB)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long videoSizeInBytes = (long)(MaxVideoSizeMB * 1024 * 1024 + 1);
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, videoSizeInBytes, "data", "file.mp4");
        
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.zip")]
    [InlineData("file.mp3")]
    [InlineData("file.png")]
    [InlineData("file.jpg")]
    [InlineData("file.pgred")]
    [InlineData("file.html")]
    [InlineData("file.cs")]
    [InlineData("file.sln")]
    public void ShouldReturnWrongVideoExtension(string videoname)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", videoname);

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("file.avi")]
    [InlineData("file.mp4")]
    [InlineData("file.amv")]
    [InlineData("file.3gp")]
    [InlineData("file.svi")]
    public void ShouldReturnValidVideoExtension(string videoname)
    {
        byte[] byteVideo = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        IFormFile videoFile = new FormFile(new MemoryStream(byteVideo), 0, byteVideo.Length, "data", videoname);

        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "fil.png");
        var dto = new VideoCreateDto();

        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.VideoPath = videoFile;

        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}