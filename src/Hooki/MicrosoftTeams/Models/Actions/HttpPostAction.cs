using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models.Actions;

public class HttpPostAction : ActionBase
{
    public override ActionType Type => ActionType.HttpPost;
    
    [JsonPropertyName("target")] public required string Target { get; set; }

    [JsonPropertyName("headers")] public List<Header>? Headers { get; set; }

    [JsonPropertyName("body")] public required string Body { get; set; }

    /// <summary>
    /// Valid values are application/json and application/x-www-form-urlencoded.
    /// If not specified, application/json is assumed
    /// </summary>
    [JsonPropertyName("bodyContentType")] public string? BodyContentType { get; set; }
}