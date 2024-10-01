using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Action
{
    [JsonPropertyName("@type")] public string Type { get; set; } = default!;

    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("targets")] public List<Target> Targets { get; set; } = [];

    [JsonPropertyName("target")] public string Target { get; set; } = default!;

    [JsonPropertyName("headers")] public List<Header> Headers { get; set; } = [];

    [JsonPropertyName("body")] public string Body { get; set; } = default!;

    [JsonPropertyName("bodyContentType")] public string BodyContentType { get; set; } = default!;

    [JsonPropertyName("inputs")] public List<InputBase> Inputs { get; set; } = [];

    [JsonPropertyName("actions")] public List<Action> Actions { get; set; } = [];

    [JsonPropertyName("addInId")] public string AddInId { get; set; } = default!;

    [JsonPropertyName("desktopCommandId")] public string DesktopCommandId { get; set; } = default!;

    [JsonPropertyName("initializationContext")] public object? InitializationContext { get; set; } 
}