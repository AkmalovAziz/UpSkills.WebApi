namespace UpSkills.Applications.Exceptions.Auth;

public class VaerificationTooManyRequestException : TooManyRequestException
{
    public VaerificationTooManyRequestException()
    {
        this.TittleMessage = "You tried more than limits !";
    }
}