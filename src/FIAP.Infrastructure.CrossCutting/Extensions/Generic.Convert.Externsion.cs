namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class GenericConvertExtension
{
    /// <summary>
    /// Convert string to another object type
    /// </summary>
    /// <param name="value">Valor</param>
    /// <typeparam name="T">New object type</typeparam>
    /// <returns>Result object</returns>
    public static T ConvertValue<T>(this string value)
    {
        return value.ConvertValue<string, T>();
    }

    /// <summary>
    /// Convert TOrigin object to TDest object
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TOrign"></typeparam>
    /// <typeparam name="TDest"></typeparam>
    /// <returns></returns>
    public static TDest ConvertValue<TOrign, TDest>(this TOrign value)
    {
        try
        {
            return (TDest)ChangeType(value, typeof(TDest));
        }
        catch
        {
            return default(TDest);
        }
    }

    /// <summary>
    /// Change type of object
    /// </summary>
    /// <param name="value"></param>
    /// <param name="conversion"></param>
    /// <returns></returns>
    private static object ChangeType(object value, Type conversion)
    {
        var t = conversion;

        if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        {
            if (value == null)
                return null;

            t = Nullable.GetUnderlyingType(t);
        }

        return Convert.ChangeType(value, t);
    }
}