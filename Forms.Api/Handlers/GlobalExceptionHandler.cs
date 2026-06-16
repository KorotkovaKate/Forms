using System;
using System.Threading;
using System.Threading.Tasks;
using Forms.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forms.Handlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        const string validationErrorMessage = "Validation Error";
        const string applicationErrorMessage = "Application Error";
        const string serverErrorMessage = "Server Error";
        
        logger.LogError(exception, exception.Message);

        var (statusCode, title) = exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, validationErrorMessage),
            BaseException e => (e.StatusCode, applicationErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, serverErrorMessage)
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
        };

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions.Add("Errors", validationException.Errors);
        }
        
        httpContext.Response.StatusCode = statusCode;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

        return true;
    }
}