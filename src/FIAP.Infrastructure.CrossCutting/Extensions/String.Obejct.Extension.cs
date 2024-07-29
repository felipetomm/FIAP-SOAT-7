using Newtonsoft.Json;

namespace FIAP.Infrastructure.CrossCutting.Extensions;

public static class StringObjectExtension
{
    /// <summary>
    /// Serialize current object to JSON
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToJson(this object value)
    {
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
    }
}