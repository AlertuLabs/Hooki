using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models.Actions;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#httppost-action
/// </summary>
public class MsTeamsHttpPostAction : MsTeamsAction
{
    public override MsTeamsActionType Type => MsTeamsActionType.HttpPost;
    
    [JsonPropertyName("target")] public required string Target { get; set; }

    [JsonPropertyName("headers")] public List<MsTeamsHeader>? Headers { get; set; }

    [JsonPropertyName("body")] public required string Body { get; set; }

    /// <summary>
    /// Valid values are application/json and application/x-www-form-urlencoded.
    /// If not specified, application/json is assumed
    /// </summary>
    [JsonPropertyName("bodyContentType")] public string? BodyContentType { get; set; }
}