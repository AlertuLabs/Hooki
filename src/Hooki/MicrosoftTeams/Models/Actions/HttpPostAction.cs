using System.Text.Json.Serialization;
using Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;
using Hooki.MicrosoftTeams.Enums;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Actions;

public class HttpPostAction : ActionBase
{
    public override ActionType Type => ActionType.HttpPost;

    [JsonPropertyName("target")] public string Target { get; set; } = default!;

    [JsonPropertyName("headers")] public List<Header> Headers { get; set; } = [];

    [JsonPropertyName("body")] public string? Body { get; set; }

    [JsonPropertyName("bodyContentType")] public string? BodyContentType { get; set; }
}