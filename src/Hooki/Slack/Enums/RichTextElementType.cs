using System.Runtime.Serialization;

namespace Hooki.Slack.Enums;

public enum RichTextElementType
{
    [EnumMember(Value = "broadcast")]
    Broadcast,
    
    [EnumMember(Value = "color")]
    Color,
    
    [EnumMember(Value = "channel")]
    Channel,
    
    [EnumMember(Value = "date")]
    Date,
    
    [EnumMember(Value = "emoji")]
    Emoji,
    
    [EnumMember(Value = "link")]
    Link,
    
    [EnumMember(Value = "text")]
    Text,
    
    [EnumMember(Value = "user")]
    User,
    
    [EnumMember(Value = "usergroup")]
    UserGroup,
}