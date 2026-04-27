using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Forms.Core.Exceptions;

//400
public class ValidationException: BaseException
{
    const string DefaultNameMessage = "Validation Errors";
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors) : base(DefaultNameMessage,
        (int)HttpStatusCode.BadRequest)
    {
        Errors = errors;
    }

    public ValidationException(string propertyName, string message) : base(DefaultNameMessage,
        (int)HttpStatusCode.BadRequest)
    {
        Errors = new Dictionary<string, string[]>
        {
            { propertyName, [message] }
        };
    }
}