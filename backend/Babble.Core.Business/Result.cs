using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace Babble.Core.Business;

public class Result
{
    public bool Success => Errors.Count == 0;
    public bool Failure => Errors.Count > 0;
    public IList<Error> Errors { get; }

    protected Result(IList<Error>? errors = null)
    {
        Errors = errors ?? new Collection<Error>();
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result<T> Ok<T>(T data)
    {
        return new Result<T>(data);
    }

    public static Result Fail(IList<Error> errors)
    {
        return new Result(errors);
    }

    public static Result<T> Fail<T>(IList<Error> errors)
    {
        return new Result<T>(errors);
    }

    public static Result FailFromValidation(IEnumerable<ValidationFailure> validationFailures)
    {
        var errors = validationFailures.Select(x => 
            new Error(x.ErrorCode, x.Severity.ToString(), x.ErrorMessage));

        return new Result(errors.ToList());
    }

    public static Result<T> FailFromValidation<T>(IEnumerable<ValidationFailure> validationFailures)
    {
        var errors = validationFailures.Select(x => 
            new Error(x.ErrorCode, x.Severity.ToString(), x.ErrorMessage));

        return new Result<T>(errors.ToList());
    }
}

public class Result<T> : Result
{
    public T? Data { get; }

    protected internal Result(IList<Error> errors) : base(errors)
    {
    }

    protected internal Result(T data)
    {
        Data = data;
    }
}