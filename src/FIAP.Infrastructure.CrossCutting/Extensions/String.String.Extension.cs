namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class StringStringExtension
{
    public static bool IsEmpty(this string @this)
    {
        if (string.IsNullOrWhiteSpace(@this))
            return true;

        if (string.IsNullOrEmpty(@this))
            return true;

        var numbersStr = @this.OnlyDigits();
        if (string.IsNullOrWhiteSpace(numbersStr))
            return true;

        if (numbersStr.ConvertValue<long>() == 0)
            return true;

        return false;
    }
}