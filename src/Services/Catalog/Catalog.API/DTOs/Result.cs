namespace Catalog.API.DTOs;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public T? Data { get; private set; }

    private Result(bool isSuccess, string message, T? data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, string.Empty, data);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(false, message, default);
    }
}