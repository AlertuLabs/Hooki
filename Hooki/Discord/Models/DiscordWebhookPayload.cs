using System.Text.Json.Serialization;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Models;

/// <summary>
/// Refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/webhook#execute-webhook
/// </summary>
public class DiscordWebhookPayload
{
    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("username")] public string? Username { get; set; }

    [JsonPropertyName("avatar_url")] public string? AvatarUrl { get; set; }

    [JsonPropertyName("tts")] public bool? Tts { get; set; }

    [JsonPropertyName("embeds")] public List<Embed>? Embeds { get; set; }

    [JsonPropertyName("allowed_mentions")] public AllowedMention? AllowedMentions { get; set; }

    [JsonPropertyName("components")] public List<object>? Components { get; set; }

    [JsonPropertyName("files")] public List<object>? Files { get; set; }

    [JsonPropertyName("payload_json")] public string? PayloadJson { get; set; }

    [JsonPropertyName("attachments")] public List<Attachment>? Attachments { get; set; }

    [JsonPropertyName("flags")] public int? Flags { get; set; }

    [JsonPropertyName("thread_name")] public string? ThreadName { get; set; }

    [JsonPropertyName("applied_tags")] public List<string>? AppliedTags { get; set; }
}