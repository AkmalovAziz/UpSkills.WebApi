using System.Net;

namespace UpSkills.Applications.Exceptions
{
    public class ExpiredException : ClientException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;
        public override string TittleMessage { get; protected set; } = string.Empty;
    }
}