using System.ComponentModel;
using System.Reflection;

using FIAP.Infrastructure.CrossCutting.Attributes;

namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Returns an Enum Description attribute
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string ToDescription(this Enum source)
    {
        return source.GetType()
            .GetField(source.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .Select(x => ((DescriptionAttribute)x).Description)
            .DefaultIfEmpty(null)
            .First();
    }

    /// <summary>
    /// Returns an Enum AlternateValue attribute
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string GetAlternateValue(this Enum source)
    {
        Type Type = source.GetType();

        FieldInfo FieldInfo = Type.GetField(source.ToString());

        AlternateValueAttribute Attribute = FieldInfo.GetCustomAttribute(
            typeof(AlternateValueAttribute)
        ) as AlternateValueAttribute;

        return Attribute.AlternateValue;
    }

    public static TAttribute GetAttribute<TAttribute>(this Enum source) where TAttribute : Attribute
    {
        var type = source.GetType();
        var name = Enum.GetName(type, source);
        return type.GetField(name) // I prefer to get attributes this way
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .SingleOrDefault();
    }

    /// <summary>
    /// Returns an Enum value by Description attribute
    /// </summary>
    /// <param name="description"></param>
    /// <param name="enumType"></param>
    /// <returns></returns>
    public static int GetFromDescription(string description, Type enumType)
    {
        foreach (var field in enumType.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(
                field,
                typeof(DescriptionAttribute)
            ) as DescriptionAttribute;

            if (attribute == null)
                continue;

            if (attribute.Description.ToLower() == description.ToLower())
                return (int)field.GetValue(null);
        }
        return 0;
    }

    /// <summary>
    /// Returns an Enum value by AlternateValue attribute
    /// </summary>
    /// <param name="alternateValue"></param>
    /// <param name="enumType"></param>
    /// <returns></returns>
    public static int GetFromAlternateValue(string alternateValue, Type enumType)
    {
        foreach (var field in enumType.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(
                field,
                typeof(AlternateValueAttribute)
            ) as AlternateValueAttribute;

            if (attribute == null)
                continue;

            if (attribute.AlternateValue.ToLower() == alternateValue.ToLower())
                return (int)field.GetValue(null);
        }
        return 0;
    }
}