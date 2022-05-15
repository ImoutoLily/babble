namespace Babble.Core.Business.Errors;

public interface IError
{
    int Code { get; }
    string Message { get; }
}