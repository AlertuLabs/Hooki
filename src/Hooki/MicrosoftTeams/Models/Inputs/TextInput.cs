using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#textinput
/// </summary>
public class TextInput : InputBase
{
    public override InputType Type => InputType.TextInput;

    [JsonPropertyName("isMultiline")] public bool? IsMultiline { get; set; }

    [JsonPropertyName("maxLength")] public int? MaxLength { get; set; }
}