namespace UpSkills.Applications.Exceptions.Files;

public class ImageNotFoundException : NotFoundExcption
{
    public ImageNotFoundException()
    {
        this.TittleMessage = "Image not found !";
    }
}