using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class SlackBlockBaseConverter : JsonConverter<SlackBlock>
{
    public override SlackBlock? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("JSON object expected.");
        }

        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("Missing 'type' property");
        }

        var typeString = typeProperty.GetString();
        return typeString switch
        {
            "actions" => JsonSerializer.Deserialize<SlackActionBlock>(root.GetRawText(), options),
            "context" => JsonSerializer.Deserialize<SlackContextBlock>(root.GetRawText(), options),
            "divider" => JsonSerializer.Deserialize<SlackDividerBlock>(root.GetRawText(), options),
            "file" => JsonSerializer.Deserialize<SlackFileBlock>(root.GetRawText(), options),
            "header" => JsonSerializer.Deserialize<SlackHeaderBlock>(root.GetRawText(), options),
            "image" => JsonSerializer.Deserialize<SlackImageBlock>(root.GetRawText(), options),
            "input" => JsonSerializer.Deserialize<SlackInputBlock>(root.GetRawText(), options),
            "rich_text" => JsonSerializer.Deserialize<SlackRichTextBlock>(root.GetRawText(), options),
            "section" => JsonSerializer.Deserialize<SlackSectionBlock>(root.GetRawText(), options),
            "video" => JsonSerializer.Deserialize<SlackVideoBlock>(root.GetRawText(), options),
            _ => throw new JsonException($"Unknown block type: {typeString}")
        };
    }

    public override void Write(Utf8JsonWriter writer, SlackBlock value, JsonSerializerOptions options)
    {
        switch (value.Type)
        {
            case SlackBlockType.ActionBlock:
                JsonSerializer.Serialize(writer, value as SlackActionBlock, options);
                break;
            case SlackBlockType.ContextBlock:
                JsonSerializer.Serialize(writer, value as SlackContextBlock, options);
                break;
            case SlackBlockType.DividerBlock:
                JsonSerializer.Serialize(writer, value as SlackDividerBlock, options);
                break;
            case SlackBlockType.FileBlock:
                JsonSerializer.Serialize(writer, value as SlackFileBlock, options);
                break;
            case SlackBlockType.HeaderBlock:
                JsonSerializer.Serialize(writer, value as SlackHeaderBlock, options);
                break;
            case SlackBlockType.ImageBlock:
                JsonSerializer.Serialize(writer, value as SlackImageBlock, options);
                break;
            case SlackBlockType.InputBlock:
                JsonSerializer.Serialize(writer, value as SlackInputBlock, options);
                break;
            case SlackBlockType.RichTextBlock:
                JsonSerializer.Serialize(writer, value as SlackRichTextBlock, options);
                break;
            case SlackBlockType.SectionBlock:
                JsonSerializer.Serialize(writer, value as SlackSectionBlock, options);
                break;
            case SlackBlockType.VideoBlock:
                JsonSerializer.Serialize(writer, value as SlackVideoBlock, options);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}