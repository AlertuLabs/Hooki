using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#multichoiceinput
/// </summary>
public class MultiChoiceInput : InputBase
{
    public override InputType Type => InputType.MultiChoiceInput;

    [JsonPropertyName("choices")] public required List<Choice> Choices { get; set; }

    [JsonPropertyName("isMultiSelect")] public bool? IsMultiSelect { get; set; }

    [JsonPropertyName("style")] public string? Style { get; set; }
}