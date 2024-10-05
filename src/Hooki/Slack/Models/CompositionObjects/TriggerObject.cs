using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#trigger
/// </summary>
public class TriggerObject
{
    /// <summary>
    /// Url must be a valid link trigger url. Refer to Slack's documentation for more details: https://api.slack.com/automation/triggers/link
    /// </summary>
    [JsonPropertyName("url")] public required string Url { get; set; }
    
    [JsonPropertyName("customizable_input_parameters")] public CustomizableInputParameter[]? CustomizableInputParameters { get; set; }
}

/// <summary>
/// The values used for these customizable_input_parameters may be visible client-side to end users.
/// You should not share sensitive information or secrets via these input parameters.
/// </summary>
public class CustomizableInputParameter
{
    public required string Name { get; set; }
    public required string Value { get; set; }
}