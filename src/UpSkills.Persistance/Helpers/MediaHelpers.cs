namespace UpSkills.Persistance.Helpers;

public class MediaHelpers
{
    public static string MakeImageName(string filename)
    {
        var fileinfo = new FileInfo(filename);
        var extension = fileinfo.Extension;
        var ImageName = "IMG" + Guid.NewGuid() + extension;

        return ImageName;
    }

    public static string[] GetImageExtension()
    {
        return new string[]
        {
            //JPG file
            ".jpg", ".jpeg",
            //PNG file
            ".png",
            //SVG file
            ".svg",
            //Bitmap
            ".bmp"
        };
    }

    public static string MakeVideoName(string filename)
    {
        var fileinfo = new FileInfo(filename);
        var extension = fileinfo.Extension;
        var VideoName = "VIDEO" + Guid.NewGuid() + extension;

        return VideoName;
    }

    public static string[] GetVideoExtension()
    {
        return new string[]
        {
            //AMV file
            ".amv", ".avi",
            //MPEG file
            ".mp4", ".m4p", ".mpg", ".mpeg", ".mpv", ".mkv",
            //SVI file
            ".svi",
            //3GP file
            ".3gp", ".mxv", ".nsv",
            //FLV file
            ".flv",  ".f4v", ".rm"
        };
    }
}