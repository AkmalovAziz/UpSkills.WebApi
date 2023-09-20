namespace UpSkills.Applications.Exceptions.Auth;

public class UserAllReadyExistsException : AllReadyExistsException
{
    public UserAllReadyExistsException()
    {
        this.TittleMessage = "This email is registered";
    }
}