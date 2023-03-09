namespace Domain.Exceptions.EntityFramework;

/// <summary>
/// Save Failure Exception
/// </summary>
public class SaveFailureException : Exception
{
	private const string DefaultMessage = "Save has failed";

	/// <summary>
	/// Constructor
	/// </summary>
	public SaveFailureException() : base(DefaultMessage)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	public SaveFailureException(string message) : base(message)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="innerException">Inner Exception</param>
	public SaveFailureException(Exception innerException) : base(DefaultMessage, innerException)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	/// <param name="innerException">Inner exception</param>
	public SaveFailureException(string message, Exception innerException) : base(message, innerException)
	{
	}

	/// <summary>
	/// Evaluate condition and throw exception
	/// </summary>
	/// <param name="condition">Condition for exception</param>
	/// <param name="message">Exception message</param>
	public static void When(bool condition, string message)
	{
		if (condition)
			throw new SaveFailureException(message);
	}
}