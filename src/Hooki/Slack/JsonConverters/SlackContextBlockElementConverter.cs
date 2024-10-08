using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.JsonConverters;

public class SlackContextBlockElementConverter : JsonConverter<List<ISlackContextBlockElement>>
{
    public override List<ISlackContextBlockElement>? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            return default;

        List<ISlackContextBlockElement> contextBlocks = default!;

        foreach (var jsonObject in JsonSerializer.Deserialize<List<JsonObject>>(ref reader, options)!)
        {
            ISlackContextBlockElement? item = jsonObject["Type"]?.GetValue<string>() switch
            {
                "image" => jsonObject.Deserialize<SlackImageElement>(options),
                "plain_text" or "mrkdwn" => jsonObject.Deserialize<SlackTextObject>(options),
                _ => null
            };

            if (item is null) continue;

            contextBlocks ??= new();
            contextBlocks.Add(item);
        }

        return contextBlocks;
    }

    public override void Write(Utf8JsonWriter writer, List<ISlackContextBlockElement> values, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var value in values)
        {
            switch (value)
            {
                case SlackImageElement image:
                    JsonSerializer.Serialize(writer, image, options);
                    break;
                case SlackTextObject text:
                    JsonSerializer.Serialize(writer, text, options);
                    break;
                default:
                    throw new JsonException($"Invalid action block element type: {value.GetType()}");
            }
        }
        writer.WriteEndArray();
    }
}