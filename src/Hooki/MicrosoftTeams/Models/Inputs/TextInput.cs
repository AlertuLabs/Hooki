using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

public class TextInput : InputBase
{
    public override InputType Type => InputType.TextInput;

    [JsonPropertyName("isMultiline")]
    public bool? IsMultiline { get; set; }

    [JsonPropertyName("maxLength")]
    public int? MaxLength { get; set; }
}