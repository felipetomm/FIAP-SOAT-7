using System.Text.RegularExpressions;

namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class StringNumberExtension
{
    /// <summary>
    /// Return only digits from string
    /// </summary>
    /// <param name="this"></param>
    /// <returns></returns>
    public static string OnlyDigits(this string @this)
    {
        if (string.IsNullOrWhiteSpace(@this))
            return @this;

        var onlyDigits = new Regex(@"[^\d]");
        return onlyDigits.Replace(@this, "");
    }
}