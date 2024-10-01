using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models.Actions;

public class OpenUriAction : ActionBase
{
    public override ActionType Type => ActionType.OpenUri;

    [JsonPropertyName("targets")] public List<Target> Targets { get; set; } = [];
}