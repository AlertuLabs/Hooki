using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#actions
/// </summary>
public class ActionBlock : BlockBase
{
    [JsonPropertyName("type")] public override BlockType Type => BlockType.ActionBlock;

    [JsonConverter(typeof(ActionBlockElementConverter))] [JsonPropertyName("elements")] public required List<IActionBlockElement> Elements { get; set; }
}

public interface IActionBlockElement { }

