using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlockType
{
    [JsonPropertyName("actions")]
    ActionBlock,
    
    [JsonPropertyName("context")]
    ContextBlock,
    
    [JsonPropertyName("divider")]
    DividerBlock,
    
    [JsonPropertyName("file")]
    FileBlock,
    
    [JsonPropertyName("header")]
    HeaderBlock,
    
    [JsonPropertyName("image")]
    ImageBlock,
    
    [JsonPropertyName("input")]
    InputBlock,
    
    [JsonPropertyName("rich_text")]
    RichTextBlock,
    
    [JsonPropertyName("section")]
    SectionBlock,
    
    [JsonPropertyName("video")]
    VideoBlock
}