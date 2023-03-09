using Domain.Exceptions;

namespace Infrastructure.Extensions;

public static class GuidExtension
{
        
    public static Guid ToGuid(this string value)
    {
        var tryParse = Guid.TryParse(value, out var guid);
        ConvertGuidException.WhenNot(tryParse, $"The guid [ {value} ] could not be converted");
        return guid;
    }
}