using System.Net;

namespace UpSkills.Applications.Exceptions;

public class NotFoundExcption : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
    public override string TittleMessage { get; protected set; } = string.Empty;
}