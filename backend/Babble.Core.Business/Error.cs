namespace Babble.Core.Business;

public class Error
{
    public Error(string code, string severity, string message)
    {
        Code = code;
        Severity = severity;
        Message = message;
    }

    public string Code { get; set; }
    public string Severity { get; set; }
    public string Message { get; set; }
}