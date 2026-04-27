using System.Net;

namespace Forms.Core.Exceptions;

//404
public class NotFoundException(string message): BaseException(message, (int)HttpStatusCode.NotFound);