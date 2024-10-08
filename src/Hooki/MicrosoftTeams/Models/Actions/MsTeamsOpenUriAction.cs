using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models.Actions;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#openuri-action
/// </summary>
public class MsTeamsOpenUriAction : MsTeamsAction
{
    public override MsTeamsActionType Type => MsTeamsActionType.OpenUri;

    [JsonPropertyName("targets")] public required List<MsTeamsTarget> Targets { get; set; }
}