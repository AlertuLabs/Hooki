using System.Text.Json;

namespace Hooki.Utilities;

/// <summary>
/// Provides utility methods for JSON serialization and deserialization using Hooki's standard options.
/// </summary>
public static class JsonHelper
{
     /// <summary>
    /// Serializes an object to a JSON string using Hooki's default JSON options.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <returns>A JSON string representation of the object.</returns>
    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, HookiJsonSerializerOptions.Default);
    }

    /// <summary>
    /// Serializes an object to a JSON string using the provided JSON options.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="options">The JSON serializer options to use. If null, Hooki's default options will be used.</param>
    /// <returns>A JSON string representation of the object.</returns>
    public static string Serialize<T>(T obj, JsonSerializerOptions? options)
    {
        return JsonSerializer.Serialize(obj, options ?? HookiJsonSerializerOptions.Default);
    }

    /// <summary>
    /// Deserializes a JSON string to an object using Hooki's default JSON options.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized object, or default(T) if deserialization fails.</returns>
    public static T? Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, HookiJsonSerializerOptions.Default);
    }

    /// <summary>
    /// Deserializes a JSON string to an object using the provided JSON options.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <param name="options">The JSON serializer options to use. If null, Hooki's default options will be used.</param>
    /// <returns>The deserialized object, or default(T) if deserialization fails.</returns>
    public static T? Deserialize<T>(string json, JsonSerializerOptions? options)
    {
        return JsonSerializer.Deserialize<T>(json, options ?? HookiJsonSerializerOptions.Default);
    }
}