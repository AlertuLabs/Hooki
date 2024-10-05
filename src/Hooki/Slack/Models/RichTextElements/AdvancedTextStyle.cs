using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.RichTextElements;

public class AdvancedTextStyle
{
    [JsonPropertyName("bold")] public bool? Bold { get; set; }
    
    [JsonPropertyName("italic")] public bool? Italic { get; set; }
    
    [JsonPropertyName("strike")] public bool? Strike { get; set; }
    
    [JsonPropertyName("highlight")] public bool? Highlight { get; set; }
    
    [JsonPropertyName("client_highlight")] public bool? ClientHighlight { get; set; }
    
    [JsonPropertyName("unlink")] public bool? Unlink { get; set; }
}