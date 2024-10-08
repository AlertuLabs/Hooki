using System.Text.Json.Serialization;

namespace Hooki.Discord.Models.BuildingBlocks;

public class DiscordEmbed
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("type")] public static string Type  => "rich";

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("timestamp")] public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    /// The color must be a decimal value. Use this link to find the value: https://www.spycolor.com
    /// </summary>
    [JsonPropertyName("color")] public int? Color { get; set; }

    [JsonPropertyName("footer")] public DiscordEmbedFooter? Footer { get; set; }

    [JsonPropertyName("image")] public DiscordImbedImage? Image { get; set; }

    [JsonPropertyName("thumbnail")] public DiscordEmbedThumbnail? Thumbnail { get; set; }

    [JsonPropertyName("video")] public DiscordEmbedVideo? Video { get; set; }

    [JsonPropertyName("provider")] public DiscordEmbedProvider? Provider { get; set; }

    [JsonPropertyName("author")] public DiscordEmbedAuthor? Author { get; set; }

    [JsonPropertyName("fields")] public List<DiscordEmbedField>? Fields { get; set; }
}

public class DiscordEmbedFooter
{
    [JsonPropertyName("text")] public string Text { get; set; } = default!;

    /// <summary>
    /// Only supports http, https and attachments
    /// </summary>
    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }

    [JsonPropertyName("proxy_icon_url")] public string? ProxyIconUrl { get; set; }
}

public class DiscordImbedImage
{
    /// <summary>
    /// Only supports http, https and attachments
    /// </summary>
    [JsonPropertyName("url")] public string Url { get; set; } = default!;

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class DiscordEmbedThumbnail
{
    /// <summary>
    /// Only supports http, https and attachments
    /// </summary>
    [JsonPropertyName("url")] public string Url { get; set; } = default!;

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class DiscordEmbedVideo
{
    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class DiscordEmbedProvider
{
    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }
}

public class DiscordEmbedAuthor
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    /// <summary>
    /// Only supports http and https
    /// </summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>
    /// Only supports http, https and attachments
    /// </summary>
    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }

    [JsonPropertyName("proxy_icon_url")] public string? ProxyIconUrl { get; set; }
}

public class DiscordEmbedField
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;

    [JsonPropertyName("inline")] public bool? Inline { get; set; }
}