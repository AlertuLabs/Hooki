using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.JsonConverters;

namespace Hooki.MicrosoftTeams.Models.Inputs;

[JsonConverter(typeof(InputBaseJsonConverter))]
public abstract class InputBase
{
    [JsonPropertyName("@type")] public abstract InputType Type { get; }

    [JsonPropertyName("id")] public string Id { get; set; } = default!;

    [JsonPropertyName("isRequired")] public bool? IsRequired { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;
}