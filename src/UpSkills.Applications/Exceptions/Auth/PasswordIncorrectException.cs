namespace UpSkills.Applications.Exceptions.Auth;

public class PasswordIncorrectException : BadRequestException
{
    public PasswordIncorrectException()
    {
        this.TittleMessage = "Password is invalid !";
    }
}