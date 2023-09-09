using System.Net;

namespace UpSkills.Applications.Exceptions;

public class BadRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    public override string TittleMessage { get; protected set; } = string.Empty;
}