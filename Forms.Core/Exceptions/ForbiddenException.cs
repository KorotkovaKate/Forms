using System.Net;

namespace Forms.Core.Exceptions;

//403
public class ForbiddenException(string message): BaseException(message, (int)HttpStatusCode.Forbidden);