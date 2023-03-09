namespace Domain.Exceptions.EntityFramework;

/// <summary>
/// Update Failure Exception
/// </summary>
public class UpdateFailureException : Exception
{
	private const string DefaultMessage = "Update has failed";

	/// <summary>
	/// Constructor
	/// </summary>
	public UpdateFailureException() : base(DefaultMessage)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	public UpdateFailureException(string message) : base(message)
	{
	}

	/// <summary>
	/// Construcrtor
	/// </summary>
	/// <param name="innerException">Inner Exception</param>
	public UpdateFailureException(Exception innerException) : base(DefaultMessage, innerException)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	/// <param name="innerException">Inner exception</param>
	public UpdateFailureException(string message, Exception innerException) : base(message, innerException)
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
			throw new UpdateFailureException(message);
	}
}