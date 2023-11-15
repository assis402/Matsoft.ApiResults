namespace Matsoft.ApiResults;

public readonly record struct ExceptionData
{
    public ExceptionData(Exception exception)
    {
        ErrorMessage = exception.Message;
        StackTrace = exception.StackTrace;
        InnerException = exception.InnerException;
    }

    public string ErrorMessage { get; }
    public string StackTrace { get; }
    public Exception InnerException { get; }
}