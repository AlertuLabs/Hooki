using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#actions
/// </summary>
public class SlackActionBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.ActionBlock;

    [JsonConverter(typeof(SlackctionBlockElementConverter))] [JsonPropertyName("elements")] public required List<ISlackActionBlockElement> Elements { get; set; }
}

public interface ISlackActionBlockElement { }