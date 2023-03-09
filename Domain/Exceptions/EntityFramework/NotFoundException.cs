namespace Domain.Exceptions.EntityFramework;

/// <summary>
/// Not Found Exception
/// </summary>
public class NotFoundException : Exception
{
	private const string DefaultMessage = "Not Found Exception";

	/// <summary>
	/// Constructor
	/// </summary>
	public NotFoundException() : base(DefaultMessage)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	public NotFoundException(string message) : base(message)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="innerException">Inner Exception</param>
	public NotFoundException(Exception innerException) : base(DefaultMessage, innerException)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	/// <param name="innerException">Inner exception</param>
	public NotFoundException(string message, Exception innerException) : base(message, innerException)
	{
	}

	/// <summary>
	/// Avaliate condition and throw exception
	/// </summary>
	/// <param name="condition">Condition for exception</param>
	/// <param name="message">Exception message</param>
	public static void When(bool condition, string message)
	{
		if (condition)
			throw new DeleteFailureException(message);
	}
}