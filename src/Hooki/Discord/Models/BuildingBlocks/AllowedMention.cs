using System.Text.Json.Serialization;
using Hooki.Discord.Enums;

namespace Hooki.Discord.Models.BuildingBlocks;

/// <summary>
/// Refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/message#allowed-mentions-object
/// </summary>
public class AllowedMention
{
    [JsonPropertyName("parse")]
    public List<AllowedMentionTypes>? Parse { get; set; }

    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }

    [JsonPropertyName("users")]
    public List<AllowedMentionTypes>? Users { get; set; }

    [JsonPropertyName("replied_user")]
    public bool? RepliedUser { get; set; }
}