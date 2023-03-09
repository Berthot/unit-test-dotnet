namespace Domain.Exceptions.EntityFramework;

/// <summary>
/// Delete fail exception
/// </summary>
public class DbRegisterExistsException : Exception
{
	private const string DefaultMessage = "A similar register already exists";

	/// <summary>
	/// Constructor
	/// </summary>
	public DbRegisterExistsException() : base(DefaultMessage)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	public DbRegisterExistsException(string message) : base(message)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="innerException">Inner Exception</param>
	public DbRegisterExistsException(Exception innerException) : base(DefaultMessage, innerException)
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="message">Exception message</param>
	/// <param name="innerException">Inner exception</param>
	public DbRegisterExistsException(string message, Exception innerException) : base(message, innerException)
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
			throw new DbRegisterExistsException(message);
	}
}