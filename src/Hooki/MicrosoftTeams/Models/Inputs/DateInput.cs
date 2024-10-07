using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#dateinput
/// </summary>
public class DateInput : InputBase
{
    public override InputType Type => InputType.DateInput;

    [JsonPropertyName("includeTime")] public bool? IncludeTime { get; set; }
}