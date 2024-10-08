# Guide: Creating Slack Webhook Payloads with Hooki

This guide will walk you through using the Hooki library to create Slack webhook payloads. The library provides a set of Plain Old CLR Objects (POCOs) that correspond to the Slack webhook payload structure.

## Table of Contents

1. [Basic Structure](#basic-structure)
2. [SlackTextObject Overview](#slacktextobject-overview)
3. [Adding Blocks](#adding-blocks)
   - [Header Block](#header-block)
   - [Section Block](#section-block)
   - [Image Block](#image-block)
   - [Actions Block](#actions-block)
   - [Context Block](#context-block)
   - [Divider Block](#divider-block)
   - [File Block](#file-block)
   - [Input Block](#input-block)
   - [Video Block](#video-block)
4. [Rich Text Elements](#rich-text-elements)
5. [Complete Example](#complete-example)
6. [Best Practices and Limitations](#best-practices-and-limitations)
7. [Additional Resources](#additional-resources)

## Basic Structure

The main object you'll be working with is `SlackWebhookPayload`. Here's a basic example of how to create one:

```csharp
using Hooki.Slack.Models;
using Hooki.Slack.Models.Blocks;

var payload = new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackHeaderBlock
        {
            Text = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "Hello, Slack!"
            }
        }
    }
};
```

## SlackTextObject Overview

The `SlackTextObject` is a fundamental component used in many Slack blocks. It represents text content and its formatting. Here's an overview of its properties:

```csharp
public class SlackTextObject
{
    public SlackTextObjectType Type { get; set; }
    public string Text { get; set; }
    public bool? Emoji { get; set; }
    public bool? Verbatim { get; set; }
}
```

- `Type`: Can be either `SlackTextObjectType.PlainText` or `SlackTextObjectType.Markdown`.
- `Text`: The actual text content.
- `Emoji`: When true, indicates that the text may contain emoji characters (only valid for PlainText).
- `Verbatim`: When true, indicates that the text should be displayed exactly as specified (only valid for Markdown).

Example usage:

```csharp
new SlackTextObject
{
    Type = SlackTextObjectType.Markdown,
    Text = "This is *bold* and _italic_ text",
    Verbatim = true
}
```

## Adding Blocks

Slack messages are composed of blocks. Here's how to add different types of blocks:

### Header Block

```csharp
new SlackHeaderBlock
{
    Text = new SlackTextObject
    {
        Type = SlackTextObjectType.PlainText,
        Text = "Important Announcement"
    }
}
```

### Section Block

```csharp
new SlackSectionBlock
{
    Text = new SlackTextObject
    {
        Type = SlackTextObjectType.Markdown,
        Text = "This is a *section* with some _formatted_ text."
    },
    Fields = new[]
    {
        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Priority:*\nHigh" },
        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Status:*\nOpen" }
    }
}
```

### Image Block

```csharp
new SlackImageBlock
{
    ImageUrl = "https://example.com/image.png",
    AltText = "An example image",
    Title = new SlackTextObject
    {
        Type = SlackTextObjectType.PlainText,
        Text = "Example Image"
    }
}
```

### Actions Block

```csharp
new SlackActionBlock
{
    Elements = new List<ISlackActionBlockElement>
    {
        new SlackButtonElement
        {
            Text = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "View Details"
            },
            Url = "https://example.com/details",
            Style = "primary"
        }
    }
}
```

### Context Block

The Context block displays message context, which can include both images and text.

```csharp
new SlackContextBlock
{
    Elements = new List<ISlackContextBlockElement>
    {
        new SlackImageElement
        {
            ImageUrl = "https://example.com/icon.png",
            AltText = "Icon"
        },
        new SlackTextObject
        {
            Type = SlackTextObjectType.Markdown,
            Text = "Last updated: Today at 9:00 AM"
        }
    }
}
```

### Divider Block

The Divider block creates a visual separation between other blocks.

```csharp
new SlackDividerBlock()
```

### File Block

The File block displays a file that has been uploaded to Slack.

```csharp
new SlackFileBlock
{
    ExternalId = "ABCDE12345",
    Source = "remote"
}
```

### Input Block

The Input block creates an input element such as a text input or a dropdown menu.

```csharp
new SlackInputBlock
{
    Label = new SlackTextObject
    {
        Type = SlackTextObjectType.PlainText,
        Text = "Your feedback"
    },
    Element = new SlackPlainTextInputElement
    {
        ActionId = "feedback_input",
        Placeholder = new SlackTextObject
        {
            Type = SlackTextObjectType.PlainText,
            Text = "Enter your feedback here"
        }
    }
}
```

### Video Block

The Video block allows you to add a video to your message.

```csharp
new SlackVideoBlock
{
    Title = new SlackTextObject
    {
        Type = SlackTextObjectType.PlainText,
        Text = "How to use our app"
    },
    TitleUrl = "https://example.com/video",
    Description = new SlackTextObject
    {
        Type = SlackTextObjectType.PlainText,
        Text = "A short tutorial on using our application"
    },
    VideoUrl = "https://example.com/video.mp4",
    AltText = "Video tutorial",
    ThumbnailUrl = "https://example.com/thumbnail.jpg"
}
```

## Rich Text Elements

For more complex text formatting, you can use Rich Text Elements:

```csharp
new SlackRichTextBlock
{
    Elements = new List<ISlackRichTextBlockElement>
    {
        new SlackRichTextSection
        {
            Elements = new ISlackRichTextElement[]
            {
                new SlackTextElement { Text = "This is " },
                new SlackTextElement { Text = "bold", Style = new SlackBasicTextStyle { Bold = true } },
                new SlackTextElement { Text = " and this is " },
                new SlackTextElement { Text = "italic", Style = new SlackBasicTextStyle { Italic = true } }
            }
        }
    }
}
```

## Complete Example

Here's a comprehensive example that puts it all together:

```csharp
var payload = new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackHeaderBlock
        {
            Text = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "New Alert Triggered"
            }
        },
        new SlackSectionBlock
        {
            Fields = new[]
            {
                new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Alert Type:*\nCPU Usage" },
                new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Severity:*\nHigh" },
                new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTime.UtcNow:f}" },
                new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Affected Resources:*\nweb-server-01, web-server-02" }
            }
        },
        new SlackDividerBlock(),
        new SlackActionBlock
        {
            Elements = new List<ISlackActionBlockElement>
            {
                new SlackButtonElement
                {
                    Text = new SlackTextObject
                    {
                        Type = SlackTextObjectType.PlainText,
                        Text = "View Alert"
                    },
                    Url = "https://alertsystem.com/alert/123",
                    Style = "primary"
                },
                new SlackButtonElement
                {
                    Text = new SlackTextObject
                    {
                        Type = SlackTextObjectType.PlainText,
                        Text = "View Dashboard"
                    },
                    Url = "https://alertsystem.com/dashboard"
                }
            }
        },
        new SlackContextBlock
        {
            Elements = new List<ISlackContextBlockElement>
            {
                new SlackImageElement
                {
                    ImageUrl = "https://example.com/alert-icon.png",
                    AltText = "Alert Icon"
                },
                new SlackTextObject
                {
                    Type = SlackTextObjectType.Markdown,
                    Text = "This alert was generated automatically by the Alert System"
                }
            }
        }
    }
};

// Serialize into JSON
var jsonString = payload.Serialize();
```

Remember to use the `Serialize()` extension method available on the `SlackWebhookPayload` class to serialize the payload into JSON using Hooki's settings for convenience and consistency.

## Best Practices and Limitations

1. Slack has a limit of 50 blocks per message. Keep your messages concise and focused.
2. The `Text` field in text objects has a maximum length of 3000 characters.
3. Use appropriate text object types: `PlainText` for simple text and `Markdown` for formatted text.
4. Button URLs must use HTTPS and be whitelisted in your Slack app settings.
5. Respect Slack's rate limits when sending webhooks.
6. Test your webhooks in a private channel before using them in public channels.
7. When using rich text elements, remember that not all formatting options are supported in all contexts.
8. File blocks require that the file has already been uploaded to Slack.
9. Video blocks currently only support videos hosted on select platforms like YouTube and Vimeo.

## Additional Resources

1. [Slack Block Kit Builder](https://app.slack.com/block-kit-builder/): Visual tool for designing Slack messages
2. [Slack API Documentation](https://api.slack.com/): Official Slack API documentation
3. [Slack Block Kit Documentation](https://api.slack.com/block-kit): Detailed information about Slack's Block Kit
4. [Slack Message Formatting Guide](https://api.slack.com/reference/surfaces/formatting): Guide to text formatting in Slack messages
5. [Slack's Block Elements](https://api.slack.com/reference/block-kit/block-elements): Comprehensive list of all block elements