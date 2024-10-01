using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Inputs;

public class DateInput : InputBase
{
    public override InputType Type => InputType.DateInput;

    [JsonPropertyName("includeTime")] public bool? IncludeTime { get; set; }
}