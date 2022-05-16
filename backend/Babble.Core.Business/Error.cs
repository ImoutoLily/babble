namespace Babble.Core.Business;

public class Error
{
    public Error(string code, string message, string severity = "Error")
    {
        Code = code;
        Severity = severity;
        Message = message;
    }

    public string Code { get; set; }
    public string Severity { get; set; }
    public string Message { get; set; }

    public static readonly Error InvalidEmail 
        = new Error("1000", "Invalid email address");
    
    public static readonly Error InvalidUserName = 
        new Error("1001", "Invalid username");

    public static readonly Error InvalidPassword = 
        new Error("1002", "Invalid password");
    
    public static readonly Error EmailInUse 
        = new Error("1003", "This email is already in use by someone else");
    
    public static readonly Error UserNameInUse 
        = new Error("1004", "This username is already in use by someone else");
}