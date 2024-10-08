using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SlackRichTextBlockElementType
{
    [EnumMember(Value = "rich_text_section")]
    RichTextSection,
    
    [EnumMember(Value = "rich_text_list")]
    RichTextList,
    
    [EnumMember(Value = "rich_text_preformatted")]
    RichTextPreformatted,
    
    [EnumMember(Value = "rich_text_quote")]
    RichTextQuote
}