using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Inputs;

public class MultiChoiceInput : InputBase
{
    public override InputType Type => InputType.MultiChoiceInput;

    [JsonPropertyName("choices")] public List<Choice> Choices { get; set; } = [];

    [JsonPropertyName("isMultiSelect")] public bool? IsMultiSelect { get; set; }

    [JsonPropertyName("style")] public string Style { get; set; } = default!;
}