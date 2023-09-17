using Microsoft.AspNetCore.Http;

namespace UpSkills.Service.Interfaces.Commons;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile file);
    public Task<bool> DeleteImageAsync(string subpath);
}