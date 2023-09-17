using Microsoft.AspNetCore.Http;
using System.Text;
using UpSkills.Persistance.Dto.Courses;
using UpSkills.Persistance.Dto.Users;
using UpSkills.Persistance.Validations.Courses;
using UpSkills.Persistance.Validations.Users;
using Xunit;

namespace UpSkills.UnitTests.ValidatorTests.Users;

public class UserUpdateValidatorTest
{
    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("Afbdfjbvhdfjvfhbvjdfbvfhdbvjhdfvbhfdbvjf")]
    public void ShouldReturnWrongFirstname(string firstname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = firstname;
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AAAAAA")]
    [InlineData("AAAAAAAA")]
    [InlineData("vjhdfvbhfdbvjf")]
    public void ShouldReturnValidFirstname(string firstname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = firstname;
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("Afbdfjbvhdfjvfhbvjdfbvfhdbvjhdfvbhfdbvjf")]
    public void ShouldReturnWrongLastname(string lastname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = lastname;
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AAAAAA")]
    [InlineData("AAAAAAAA")]
    [InlineData("vjhdfvbhfdbvjf")]
    public void ShouldReturnValidLastname(string lastname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = lastname;
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("11/2/12")]
    [InlineData("1/1/11")]
    [InlineData("10/12/21")]
    [InlineData("10/12/212")]
    [InlineData("0/12/2122")]
    [InlineData("10.12.2122")]
    [InlineData("10/12/2122y")]
    public void ShouldReturnWrongBirthDate(string date)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = date;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("12/12/2012")]
    [InlineData("09/28/2023")]
    public void ShouldReturnValidBirthDate(string date)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = date;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("998545977")]
    [InlineData("998998545977")]
    [InlineData("(99)8545977")]
    [InlineData("8545977")]
    public void ShouldReturnWrongPhonenumber(string number)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = number;
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("+998998545977")]
    [InlineData("+998998525262")]
    [InlineData("+998330051234")]
    public void ShouldReturnValidPhonenumber(string number)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        var dto = new UserUpdateDto();

        dto.FirstName = "Aziz";
        dto.LastName = "Akmalov";
        dto.ImagePath = imageFile;
        dto.BirthDate = "11/04/2003";
        dto.PhoneNumber = number;
        dto.Description = "ksdvjsdbvjhsbdjvbshdvbjsdsjdhb";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

    public void ShouldReturnWrongImageSize(float MaxImageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic products to our clients");
        long imageSizeInBytes = (long)(MaxImageSizeMB * 1024 * 1024 + 1);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        var dto = new UserUpdateDto();

        dto.FirstName = "akmalov";
        dto.LastName = "Akmalov";
        dto.BirthDate = "11/04/2003";
        dto.ImagePath = imageFile;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";

        var validator = new UserUpdateValidator();
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
        var dto = new UserUpdateDto();

        dto.FirstName = "akmalov";
        dto.LastName = "Akmalov";
        dto.BirthDate = "11/04/2003";
        dto.ImagePath = imageFile;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";

        var validator = new UserUpdateValidator();
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
        var dto = new UserUpdateDto();

        dto.FirstName = "akmalov";
        dto.LastName = "Akmalov";
        dto.BirthDate = "11/04/2003";
        dto.ImagePath = imageFile;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";

        var validator = new UserUpdateValidator();
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
        var dto = new UserUpdateDto();

        dto.FirstName = "akmalov";
        dto.LastName = "Akmalov";
        dto.BirthDate = "11/04/2003";
        dto.ImagePath = imageFile;
        dto.PhoneNumber = "+998998545977";
        dto.Description = "hbjbcjdsvsdhvbjhdsbvsjbvjsdhbvjsdbvhsdbj";

        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}