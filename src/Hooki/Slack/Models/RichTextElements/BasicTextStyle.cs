using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.RichTextElements;

public class BasicTextStyle
{
    [JsonPropertyName("Bold")] public bool? Bold { get; set; }
    
    [JsonPropertyName("italic")] public bool? Italic { get; set; }
    
    [JsonPropertyName("strike")] public bool? Strike { get; set; }
    
    [JsonPropertyName("code")] public bool? Code { get; set; }
}