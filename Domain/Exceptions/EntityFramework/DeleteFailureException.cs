namespace Domain.Exceptions.EntityFramework;

/// <summary>
/// Delete fail exception
/// </summary>
public class DeleteFailureException : Exception
{
	private const string DefaultMessage = "Delete has failed";

	/// <summary>
	/// Constructor
	/// </summary>
	public DeleteFailureException() : base(DefaultMessage)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	public DeleteFailureException(string message) : base(message)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="innerException">Inner Exception</param>
	public DeleteFailureException(Exception innerException) : base(DefaultMessage, innerException)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	/// <param name="innerException">Inner exception</param>
	public DeleteFailureException(string message, Exception innerException) : base(message, innerException)
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