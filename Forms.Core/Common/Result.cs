using System.Net;

namespace Forms.Core.Common;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public int StatusCode { get; set; }

    private Result(bool isSuccess, T? data, string? errorMessage, int statusCode)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public static Result<T> Success(T? data)
        => new(true, data, null, (int)HttpStatusCode.OK);
    public static Result<T> SuccessNoContent() 
        => new(true, default, null, (int)HttpStatusCode.NoContent); 
    public static Result<T> Failure(string errorMessage, HttpStatusCode statusCode) 
        => new(false, default, errorMessage, (int)statusCode);
}