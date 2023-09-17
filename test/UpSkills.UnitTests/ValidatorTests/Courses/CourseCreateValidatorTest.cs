using Microsoft.AspNetCore.Http;
using System.Text;
using UpSkills.Persistance.Dto.Courses;
using UpSkills.Persistance.Validations.Courses;
using Xunit;

namespace UpSkills.UnitTests.ValidatorTests.Courses;

public class CourseCreateValidatorTest
{
    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("dfbvhdfbvjhdfvhdfjvbdfhbvdfhdfhbjkjnfbhdfhbvjdfbhdf")]
    [InlineData("aaajhbfvbvbfhbvhdfbvhdfbvjhdfvhdfjvbfjbhdfvjdfhvdfvbdf")]
    public void ShouldReturnWrongName(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = name;
        dto.Description = "ndjfbfhjfbvjhfbvhfbjvdfhvfdjfv";
        dto.PricePerMonth = 15000;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("Akmalov")]
    [InlineData("Aziz")]
    [InlineData("AzizAkmalov")]
    public void ShouldReturnValidName(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = name;
        dto.Description = "ndjfbfhjfbvjhfbvhfbjvdfhvfdjfv";
        dto.PricePerMonth = 15000;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    [InlineData("212sfd5")]
    [InlineData("dhbshjjh")]
    public void ShouldReturnWrongDescription(string description)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = "Akmalov";
        dto.Description = description;
        dto.PricePerMonth = 15000;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("jhfvbfdbvgdfbdvfdfa")]
    [InlineData("aa151665fdnbjhhdfhjfhbfj")]
    [InlineData("aaafvn vjbdh dvjsbh")]
    [InlineData("dhbshjf2165   vdsvdfvjh")]
    public void ShouldReturnValidDescription(string description)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = "Akmalov";
        dto.Description = description;
        dto.PricePerMonth = 15000;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-11515)]

    public void ShouldReturnWrongPrice(float price)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = "Akmalov";
        dto.Description = "nvjfhvbfhbvhfdjfbfh";
        dto.PricePerMonth = price;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(15000)]
    [InlineData(150.151)]
    [InlineData(15.151)]
    public void ShouldReturnValidPrice(float price)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new CourseCreateDto();

        dto.Name = "Akmalov";
        dto.Description = "jhbvdhvbhsdbvjdvsvds";
        dto.PricePerMonth = price;
        dto.ImagePath = imageFile;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(5.1)]
    [InlineData(10)]
    [InlineData(5.5)]
    [InlineData(6)]
    [InlineData(8)]
    public void ShouldReturnWrongImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024 + 1);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new CourseCreateDto();

        dto.Name = "akmalov";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerMonth = 15000;

        var validator = new CourseCreateValidator();
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
        var dto = new CourseCreateDto();

        dto.Name = "akmalov";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerMonth = 15000;

        var validator = new CourseCreateValidator();
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
        var dto = new CourseCreateDto();

        dto.Name = "akmalov";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerMonth = 15000;

        var validator = new CourseCreateValidator();
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
        var dto = new CourseCreateDto();

        dto.Name = "akmalov";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";
        dto.ImagePath = imageFile;
        dto.PricePerMonth = 15000;

        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}