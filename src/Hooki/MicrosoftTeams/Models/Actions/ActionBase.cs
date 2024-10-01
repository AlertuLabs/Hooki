using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Actions;

[JsonDerivedType(typeof(OpenUriAction), typeDiscriminator: nameof(ActionType.OpenUri))]
[JsonDerivedType(typeof(HttpPostAction), typeDiscriminator: nameof(ActionType.HttpPost))]
[JsonDerivedType(typeof(ActionCardAction), typeDiscriminator: nameof(ActionType.ActionCard))]
[JsonDerivedType(typeof(InvokeAddInCommandAction), typeDiscriminator: nameof(ActionType.InvokeAddInCommand))]
public abstract class ActionBase
{
    [JsonPropertyName("@type")] public abstract ActionType Type { get; }

    [JsonPropertyName("name")] public string Name { get; set; } = default!;
}