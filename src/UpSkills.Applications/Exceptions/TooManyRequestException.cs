using System.Net;

namespace UpSkills.Applications.Exceptions;

public class TooManyRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;
    public override string TittleMessage { get; protected set; } = string.Empty;
}