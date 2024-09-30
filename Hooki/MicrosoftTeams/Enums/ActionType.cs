using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActionType
{
    [JsonPropertyName("OpenUri")]
    OpenUri,

    [JsonPropertyName("HttpPOST")]
    HttpPost,

    [JsonPropertyName("ActionCard")]
    ActionCard,

    [JsonPropertyName("InvokeAddInCommand")]
    InvokeAddInCommand
}