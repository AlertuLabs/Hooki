using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#context
/// </summary>
public class ContextBlock : BlockBase
{
    public override BlockType Type => BlockType.ActionBlock;

    //ToDo: Add type safety for the compatible block elements 
    [JsonPropertyName("elements")] public required object[] Elements { get; set; }
}