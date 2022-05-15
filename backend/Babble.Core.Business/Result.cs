using Babble.Core.Business.Errors;

namespace Babble.Core.Business;

public class Result
{
    public bool Success => Error is null;
    public bool Failure => Error is not null;
    public IError? Error { get; }

    protected Result(IError? error = null)
    {
        Error = error;
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result<T> Ok<T>(T data)
    {
        return new Result<T>(data);
    }

    public static Result Fail(IError error)
    {
        return new Result(error);
    }

    public static Result<T> Fail<T>(IError error)
    {
        return new Result<T>(error);
    }
}

public class Result<T> : Result
{
    public T? Data { get; }

    protected internal Result(IError error) : base(error)
    {
    }

    protected internal Result(T data)
    {
        Data = data;
    }
}