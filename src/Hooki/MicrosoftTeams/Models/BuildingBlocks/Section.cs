using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Section
{
    [JsonPropertyName("title")] public string Title { get; set; } = default!;

    [JsonPropertyName("startGroup")]
    public bool? StartGroup { get; set; } = default!;

    [JsonPropertyName("activityImage")]
    public string ActivityImage { get; set; } = default!;

    [JsonPropertyName("activityTitle")]
    public string ActivityTitle { get; set; } = default!;

    [JsonPropertyName("activitySubtitle")]
    public string ActivitySubtitle { get; set; } = default!;

    [JsonPropertyName("activityText")]
    public string ActivityText { get; set; } = default!;

    [JsonPropertyName("heroImage")]
    public Image? HeroImage { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = default!;

    [JsonPropertyName("facts")] public List<Fact> Facts { get; set; } = [];

    [JsonPropertyName("images")] public List<Image> Images { get; set; } = [];

    [JsonPropertyName("potentialAction")] public List<Action> PotentialActions { get; set; } = [];
}