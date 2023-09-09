namespace UpSkills.Applications.Exceptions.Files;

public class VideoNotFoundException : NotFoundExcption
{
    public VideoNotFoundException()
    {
        this.TittleMessage = "Video not found !";
    }
}