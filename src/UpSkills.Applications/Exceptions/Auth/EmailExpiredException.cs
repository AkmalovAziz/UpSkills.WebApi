namespace UpSkills.Applications.Exceptions.Auth
{
    public class EmailExpiredException : ExpiredException
    {
        public EmailExpiredException()
        {
            this.TittleMessage = "This email is expired! ";
        }
    }
}