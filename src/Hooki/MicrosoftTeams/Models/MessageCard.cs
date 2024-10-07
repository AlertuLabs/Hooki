using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Models;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#design-guidelines
/// </summary>
public class MessageCard
{
    [JsonPropertyName("@type")] public static string Type => "MessageCard";

    [JsonPropertyName("@context")] public static string Context  => "https://schema.org/extensions";

    [JsonPropertyName("correlationId")] public string? CorrelationId { get; set; }

    [JsonPropertyName("expectedActors")] public List<string>? ExpectedActors { get; set; } = null;

    [JsonPropertyName("originator")] public string? Originator { get; set; }

    /// <summary>
    /// Required when Text has not been provided
    /// </summary>
    [JsonPropertyName("summary")] public string? Summary { get; set; }

    [JsonPropertyName("themeColor")] public string? ThemeColor { get; set; }

    [JsonPropertyName("hideOriginalBody")] public bool? HideOriginalBody { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }

    /// <summary>
    /// Required when a summary has not been provided
    /// </summary>
    [JsonPropertyName("text")] public string? Text { get; set; }

    [JsonPropertyName("sections")] public List<Section>? Sections { get; set; }
    
    [JsonPropertyName("potentialAction")] public List<ActionBase>? PotentialActions { get; set; }
}