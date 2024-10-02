using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models.Actions;

public class HttpPostAction : ActionBase
{
    public override ActionType Type => ActionType.HttpPost;

    [JsonPropertyName("target")] public string Target { get; set; } = default!;

    [JsonPropertyName("headers")] public List<Header> Headers { get; set; } = [];

    [JsonPropertyName("body")] public string? Body { get; set; }

    //ToDo: Create an enum for content type
    [JsonPropertyName("bodyContentType")] public string? BodyContentType { get; set; }
}