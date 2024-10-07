using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class BroadcastElement : IRichTextElement
{
    [JsonPropertyName("type")] public RichTextElementType Type => RichTextElementType.Broadcast;
    
    [JsonPropertyName("range")] public required BroadcastRangeType Range { get; set; }
}

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum BroadcastRangeType
{
    [EnumMember(Value = "here")]
    Here,
    
    [EnumMember(Value = "channel")]
    Channel,
    
    [EnumMember(Value = "everyone")]
    Everyone
}