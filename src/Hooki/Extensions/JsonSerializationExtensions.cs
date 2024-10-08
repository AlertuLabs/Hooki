using System.Text.Json;
using Hooki.Utilities;

namespace Hooki.Extensions;

public static class JsonSerializationExtensions
{
    public static string Serialize<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj, HookiJsonSerializerOptions.Default);
    }
}