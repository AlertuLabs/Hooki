using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SlackTextObjectType
{
    [EnumMember(Value = "plain_text")]
    PlainText,
    
    [EnumMember(Value = "mrkdwn")]
    Markdown
}