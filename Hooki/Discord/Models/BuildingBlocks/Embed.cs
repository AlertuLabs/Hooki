using System.Text.Json.Serialization;

namespace Hooki.Discord.Models.BuildingBlocks;

public class Embed
{
    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; } = "rich";

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("timestamp")] public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    /// The color must be a decimal value. Use this link to find the value: https://www.spycolor.com
    /// </summary>
    [JsonPropertyName("color")] public int? Color { get; set; }

    [JsonPropertyName("footer")] public EmbedFooter? Footer { get; set; }

    [JsonPropertyName("image")] public EmbedImage? Image { get; set; }

    [JsonPropertyName("thumbnail")] public EmbedThumbnail? Thumbnail { get; set; }

    [JsonPropertyName("video")] public EmbedVideo? Video { get; set; }

    [JsonPropertyName("provider")] public EmbedProvider? Provider { get; set; }

    [JsonPropertyName("author")] public EmbedAuthor? Author { get; set; }

    [JsonPropertyName("fields")] public List<EmbedField>? Fields { get; set; }
}

public class EmbedFooter
{
    [JsonPropertyName("text")] public string Text { get; set; } = default!;

    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }

    [JsonPropertyName("proxy_icon_url")] public string? ProxyIconUrl { get; set; }
}

public class EmbedImage
{
    [JsonPropertyName("url")] public string Url { get; set; } = default!;

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class EmbedThumbnail
{
    [JsonPropertyName("url")] public string Url { get; set; } = default!;

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class EmbedVideo
{
    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("proxy_url")] public string? ProxyUrl { get; set; }

    [JsonPropertyName("height")] public int? Height { get; set; }

    [JsonPropertyName("width")] public int? Width { get; set; }
}

public class EmbedProvider
{
    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }
}

public class EmbedAuthor
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }

    [JsonPropertyName("proxy_icon_url")] public string? ProxyIconUrl { get; set; }
}

public class EmbedField
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;

    [JsonPropertyName("inline")] public bool? Inline { get; set; }
}

public class PollResultEmbed : Embed
{
    [JsonPropertyName("poll_question_text")] public string? PollQuestionText { get; set; }

    [JsonPropertyName("victor_answer_votes")] public int VictorAnswerVotes { get; set; }

    [JsonPropertyName("total_votes")] public int TotalVotes { get; set; }

    [JsonPropertyName("victor_answer_id")] public string? VictorAnswerId { get; set; }

    [JsonPropertyName("victor_answer_text")] public string? VictorAnswerText { get; set; }

    [JsonPropertyName("victor_answer_emoji_id")] public string? VictorAnswerEmojiId { get; set; }

    [JsonPropertyName("victor_answer_emoji_name")] public string? VictorAnswerEmojiName { get; set; }

    [JsonPropertyName("victor_answer_emoji_animated")] public bool? VictorAnswerEmojiAnimated { get; set; }
}