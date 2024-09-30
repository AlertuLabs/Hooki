using System.Text.Json.Serialization;
using Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Actions;
using Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#design-guidelines
/// </summary>
public class MessageCard
{
    [JsonPropertyName("@type")]
    public string Type { get; set; } = "MessageCard";

    [JsonPropertyName("@context")]
    public string Context { get; set; } = "https://schema.org/extensions";

    [JsonPropertyName("correlationId")] public string CorrelationId { get; set; } = default!;

    [JsonPropertyName("expectedActors")]
    public List<string> ExpectedActors { get; set; } = default!;

    [JsonPropertyName("originator")]
    public string Originator { get; set; } = default!;

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = default!;

    [JsonPropertyName("themeColor")]
    public string ThemeColor { get; set; } = default!;

    [JsonPropertyName("hideOriginalBody")]
    public bool? HideOriginalBody { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = default!;

    [JsonPropertyName("text")]
    public string Text { get; set; } = default!;

    [JsonPropertyName("sections")]
    public List<Section> Sections { get; set; } = default!;

    [JsonPropertyName("potentialAction")] public List<ActionBase> PotentialActions { get; set; } = [];
}