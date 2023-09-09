namespace UpSkills.Applications.Exceptions.Users;

public class UserNotFoundException : NotFoundExcption
{
    public UserNotFoundException()
    {
        this.TittleMessage = "User not found !";
    }
}