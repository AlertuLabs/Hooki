using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#file_input
/// </summary>
public class SlackFileInputElement : SlackBlockElement, IInputBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.FileInput;

    [JsonPropertyName("filetypes")] public List<string>? FileTypes { get; set; }

    /// <summary>
    /// Supported file types: https://api.slack.com/types/file#types
    /// </summary>
    [JsonPropertyName("max_files")] public int? MaxFiles { get; set; }
}