using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SlackBlockType
{
    [EnumMember(Value = "actions")]
    ActionBlock,
    
    [EnumMember(Value = "context")]
    ContextBlock,
    
    [EnumMember(Value = "divider")]
    DividerBlock,
    
    [EnumMember(Value = "file")]
    FileBlock,
    
    [EnumMember(Value = "header")]
    HeaderBlock,
    
    [EnumMember(Value = "image")]
    ImageBlock,
    
    [EnumMember(Value = "input")]
    InputBlock,
    
    [EnumMember(Value = "rich_text")]
    RichTextBlock,
    
    [EnumMember(Value = "section")]
    SectionBlock,
    
    [EnumMember(Value = "video")]
    VideoBlock
}