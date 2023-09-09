namespace UpSkills.Applications.Exceptions.Admin;

public class AdminNotFoundException : NotFoundExcption
{
    public AdminNotFoundException()
    {
        this.TittleMessage = "Admin not found !";
    }
}