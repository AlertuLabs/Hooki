using System.Text.Json.Serialization;

namespace Hooki.Utilities;

public static class HookiJsonSerializerOptions
{
    private static readonly Lazy<System.Text.Json.JsonSerializerOptions> DefaultOptions = new(CreateDefaultOptions);

    private static System.Text.Json.JsonSerializerOptions CreateDefaultOptions()
    {
        return new System.Text.Json.JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
    }
    
    /// <summary>
    /// Gets the default JSON serializer options used throughout the Hooki library.
    /// This instance is created only once and shared across all usages.
    /// </summary>
    public static System.Text.Json.JsonSerializerOptions Default => DefaultOptions.Value;

    /// <summary>
    /// Creates a new instance of JsonSerializerOptions with the default Hooki settings.
    /// Use this method if you need to modify the options for a specific use case.
    /// </summary>
    /// <returns>A new instance of JsonSerializerOptions with default Hooki settings.</returns>
    public static System.Text.Json.JsonSerializerOptions CreateDefault() => new(Default);
}