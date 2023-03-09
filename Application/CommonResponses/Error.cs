using Domain.Enum;

namespace Application.CommonResponses;

public class Error
{
    public Error(string message, int errorType)
    {
        Message = message;
        ErrorType = errorType;
    }

    public Error(string message, EErrorType errorType)
    {
        Message = message;
        ErrorType = (int) errorType;
    }

    public string Message { get; init; }

    public int ErrorType { get; init; }
}