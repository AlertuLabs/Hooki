using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class BlockBaseConverter : JsonConverter<BlockBase>
{
    public override BlockBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            "actions" => JsonSerializer.Deserialize<ActionBlock>(root.GetRawText(), options),
            "context" => JsonSerializer.Deserialize<ContextBlock>(root.GetRawText(), options),
            "divider" => JsonSerializer.Deserialize<DividerBlock>(root.GetRawText(), options),
            "file" => JsonSerializer.Deserialize<FileBlock>(root.GetRawText(), options),
            "header" => JsonSerializer.Deserialize<HeaderBlock>(root.GetRawText(), options),
            "image" => JsonSerializer.Deserialize<ImageBlock>(root.GetRawText(), options),
            "input" => JsonSerializer.Deserialize<InputBlock>(root.GetRawText(), options),
            "rich_text" => JsonSerializer.Deserialize<RichTextBlock>(root.GetRawText(), options),
            "section" => JsonSerializer.Deserialize<SectionBlock>(root.GetRawText(), options),
            "video" => JsonSerializer.Deserialize<VideoBlock>(root.GetRawText(), options),
            _ => throw new JsonException($"Unknown block type: {typeString}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BlockBase value, JsonSerializerOptions options)
    {
        switch (value.Type)
        {
            case BlockType.ActionBlock:
                JsonSerializer.Serialize(writer, value as ActionBlock, options);
                break;
            case BlockType.ContextBlock:
                JsonSerializer.Serialize(writer, value as ContextBlock, options);
                break;
            case BlockType.DividerBlock:
                JsonSerializer.Serialize(writer, value as DividerBlock, options);
                break;
            case BlockType.FileBlock:
                JsonSerializer.Serialize(writer, value as FileBlock, options);
                break;
            case BlockType.HeaderBlock:
                JsonSerializer.Serialize(writer, value as HeaderBlock, options);
                break;
            case BlockType.ImageBlock:
                JsonSerializer.Serialize(writer, value as ImageBlock, options);
                break;
            case BlockType.InputBlock:
                JsonSerializer.Serialize(writer, value as InputBlock, options);
                break;
            case BlockType.RichTextBlock:
                JsonSerializer.Serialize(writer, value as RichTextBlock, options);
                break;
            case BlockType.SectionBlock:
                JsonSerializer.Serialize(writer, value as SectionBlock, options);
                break;
            case BlockType.VideoBlock:
                JsonSerializer.Serialize(writer, value as VideoBlock, options);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}