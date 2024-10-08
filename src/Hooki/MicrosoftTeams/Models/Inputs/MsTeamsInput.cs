using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.JsonConverters;

namespace Hooki.MicrosoftTeams.Models.Inputs;

[JsonConverter(typeof(MsTeamsJsonConverter))]
public abstract class MsTeamsInput
{
    [JsonPropertyName("@type")] public abstract MsTeamsInputType Type { get; }

    [JsonPropertyName("id")] public required string Id { get; set; }

    [JsonPropertyName("isRequired")] public bool? IsRequired { get; set; }

    [JsonPropertyName("title")] public required string Title { get; set; }

    [JsonPropertyName("value")] public string? Value { get; set; }
}