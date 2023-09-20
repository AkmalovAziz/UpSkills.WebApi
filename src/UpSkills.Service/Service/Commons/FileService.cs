using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Commons;
using static System.Net.Mime.MediaTypeNames;

namespace UpSkills.Service.Service.Commons;

public class FileService : IFileService
{
    private readonly string IMAGE = "images";
    private readonly string MEDIA = "media";
    private readonly string VIDEO = "videos";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        else return false;
    }

    public async Task<bool> DeleteVideoAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }

        else return false;
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelpers.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGE, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);
        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }

    public async Task<string> UploadVideoAsync(IFormFile video)
    {
        string newVideoName = MediaHelpers.MakeVideoName(video.FileName);
        string subpath = Path.Combine(MEDIA, VIDEO, newVideoName);
        string path = Path.Combine(ROOTPATH, subpath);
        var stream = new FileStream(path, FileMode.Create);
        await video.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }
}