using System.Net;

namespace Forms.Core.Exceptions;

//401
public class UnauthorizedException(string message): BaseException(message, (int)HttpStatusCode.Unauthorized);