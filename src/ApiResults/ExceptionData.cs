namespace ApiResults;

public readonly record struct ExceptionData
{
    public ExceptionData(Exception exception)
    {
        ErrorMessage = exception.Message;
        StackTrace = exception.StackTrace;
        InnerException = exception.InnerException;
    }

    public readonly string ErrorMessage { get; }
    public readonly string StackTrace { get; }
    public readonly Exception InnerException { get; }
}