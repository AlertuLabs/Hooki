using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#file_input
/// </summary>
public class FileInputElement : BlockElementBase, IInputBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.FileInput;

    [JsonPropertyName("filetypes")] public List<string>? FileTypes { get; set; }

    /// <summary>
    /// Supported file types: https://api.slack.com/types/file#types
    /// </summary>
    [JsonPropertyName("max_files")] public int? MaxFiles { get; set; }
}