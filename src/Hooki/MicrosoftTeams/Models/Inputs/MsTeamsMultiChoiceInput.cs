using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#multichoiceinput
/// </summary>
public class MsTeamsMultiChoiceInput : MsTeamsInput
{
    public override MsTeamsInputType Type => MsTeamsInputType.MultiChoiceInput;

    [JsonPropertyName("choices")] public required List<MsTeamsChoice> Choices { get; set; }

    [JsonPropertyName("isMultiSelect")] public bool? IsMultiSelect { get; set; }

    [JsonPropertyName("style")] public MsTeamsInputStyle? Style { get; set; }
}