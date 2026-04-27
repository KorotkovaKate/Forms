using System.Net;

namespace Forms.Core.Exceptions;

//409
public class ConflictException(string message): BaseException(message, (int)HttpStatusCode.Conflict);