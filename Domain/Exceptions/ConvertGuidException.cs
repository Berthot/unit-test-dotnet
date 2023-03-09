namespace Domain.Exceptions;

public class ConvertGuidException : Exception
{
    private const string DefaultMessage = "Can't convert Guid";

    /// <summary>
    /// Constructor
    /// </summary>
    public ConvertGuidException() : base(DefaultMessage)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public ConvertGuidException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="innerException">Inner Exception</param>
    public ConvertGuidException(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    public ConvertGuidException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Evaluate condition and throw exception
    /// </summary>
    /// <param name="condition">Condition for exception</param>
    /// <param name="message">Exception message</param>
    public static void When(bool condition, string message)
    {
        if (condition) throw new ConvertGuidException(message);
    }

    /// <summary>
    /// Evaluate condition and throw exception
    /// </summary>
    /// <param name="condition">Condition for exception</param>
    /// <param name="message">Exception message</param>
    public static void WhenNot(bool condition, string message)
    {
        if (condition == false) throw new ConvertGuidException(message);
    }
}