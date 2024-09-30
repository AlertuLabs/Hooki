using System.Text.Json.Serialization;

namespace Hooki.Discord.Models.BuildingBlocks;

public class Attachment
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("filename")]
    public string Filename { get; set; } = "";

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

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

public static class AttachmentFlags
{
    public const int IS_REMIX = 1 << 2;
}