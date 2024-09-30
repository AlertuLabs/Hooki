using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InputType
{
    [JsonPropertyName("TextInput")]
    TextInput,
    
    [JsonPropertyName("DateInput")]
    DateInput,
    
    [JsonPropertyName("MultichoiceInput")]
    MultiChoiceInput
}1