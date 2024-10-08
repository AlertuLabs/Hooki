using System.Text.Json.Serialization;
using Hooki.Discord.Enums;

namespace Hooki.Discord.Models.BuildingBlocks;

/// <summary>
/// Refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/message#allowed-mentions-object
/// </summary>
public class DiscordAllowedMention
{
    [JsonPropertyName("parse")] public List<DiscordAllowedMentionType>? Parse { get; set; }

    /// <summary>
    /// Array of role ids to mention
    /// </summary>
    [JsonPropertyName("roles")] public List<string>? Roles { get; set; }

    /// <summary>
    /// Array of user ids to mention
    /// </summary>
    [JsonPropertyName("users")] public List<string>? Users { get; set; }

    [JsonPropertyName("replied_user")] public bool? RepliedUser { get; set; }
}