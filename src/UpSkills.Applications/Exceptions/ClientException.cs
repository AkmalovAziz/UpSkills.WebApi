using System.Net;

namespace UpSkills.Applications.Exceptions;

public abstract class ClientException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public abstract string TittleMessage { get; protected set; }
}