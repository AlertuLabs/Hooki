using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.JsonConverters;

namespace Hooki.MicrosoftTeams.Models.Actions;

[JsonConverter(typeof(ActionBaseConverter))]
public abstract class ActionBase
{
    [JsonPropertyName("@type")] public abstract ActionType Type { get; }

    [JsonPropertyName("name")] public string Name { get; set; } = default!;
}