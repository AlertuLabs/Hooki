using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#context
/// </summary>
public class SlackContextBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.ContextBlock;
    
    [JsonConverter(typeof(SlackContextBlockElementConverter))] [JsonPropertyName("elements")] public required List<ISlackContextBlockElement> Elements { get; set; }
}

public interface ISlackContextBlockElement { }