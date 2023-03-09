namespace Infrastructure.Extensions;

public static class UtilsExtensions
{
    public static T ThrowIfNull<T>(this T value)
    {
        if(value == null) throw new ArgumentNullException(nameof(value));
        return value;
    }
}