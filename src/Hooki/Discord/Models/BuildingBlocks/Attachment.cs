using System.Text.Json.Serialization;

namespace Hooki.Discord.Models.BuildingBlocks;

public class Attachment
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("filename")]
    public string? FileName { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// When provided, use the attachment's media type value
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; set; }

    /// <summary>
    /// Height of file if it's an image
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Width of file if it's an image
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("ephemeral")]
    public bool? Ephemeral { get; set; }

    [JsonPropertyName("duration_secs")]
    public float? DurationSecs { get; set; }

    [JsonPropertyName("waveform")]
    public string? Waveform { get; set; }

    [JsonPropertyName("flags")]
    public int? Flags { get; set; }
}