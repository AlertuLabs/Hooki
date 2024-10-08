using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.JsonConverters;

namespace Hooki.MicrosoftTeams.Models.Actions;

[JsonConverter(typeof(MsTeamsActionConverter))]
public abstract class MsTeamsAction
{
    [JsonPropertyName("@type")] public abstract MsTeamsActionType Type { get; }

    [JsonPropertyName("name")] public required string Name { get; set; }
}