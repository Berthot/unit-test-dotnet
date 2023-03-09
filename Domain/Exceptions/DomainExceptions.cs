namespace Domain.Exceptions;

public class DomainExceptions : Exception
{
    private const string DefaultMessage = "Domain Exception";

    /// <summary>
    /// Constructor
    /// </summary>
    public DomainExceptions() : base(DefaultMessage)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public DomainExceptions(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="innerException">Inner Exception</param>
    public DomainExceptions(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    public DomainExceptions(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Evaluate condition and throw exception
    /// </summary>
    /// <param name="condition">Condition for exception</param>
    /// <param name="message">Exception message</param>
    public static void When(bool condition, string message)
    {
        if (condition) throw new DomainExceptions(message);
    }

    /// <summary>
    /// Evaluate condition and throw exception
    /// </summary>
    /// <param name="condition">Condition for exception</param>
    /// <param name="message">Exception message</param>
    public static void WhenNot(bool condition, string message)
    {
        if (condition == false) throw new DomainExceptions(message);
    }
}