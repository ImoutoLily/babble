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

    public static readonly Error EmailInUse 
        = new Error("1000", "Error", "This email is already in use by someone else");
    public static readonly Error UserNameInUse 
        = new Error("1001", "Error", "This username is already in use by someone else");
}