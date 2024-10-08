# Guide: Creating Discord Webhook Payloads with Hooki

This guide will walk you through using the Hooki library to create Discord webhook payloads. The library provides a set of Plain Old CLR Objects (POCOs) that correspond to the Discord webhook payload structure.

## Table of Contents

1. [Basic Structure](#basic-structure)
2. [Adding Embeds](#adding-embeds)
   - [Embed Author](#embed-author)
   - [Embed Fields](#embed-fields)
   - [Embed Images](#embed-images)
3. [Polls](#polls)
4. [Attachments and Files](#attachments-and-files)
   - [Multipart/form-data](#multipartform-data)
   - [Attachments](#attachments)
   - [Using Files with Attachments](#using-files-with-attachments)
5. [Complete Example](#complete-example)
6. [Markdown Styling in Discord Webhooks](#markdown-styling-in-discord-webhooks)
7. [Best Practices and Limitations](#best-practices-and-limitations)
8. [Additional Resources](#additional-resources)

## Basic Structure

The main object you'll be working with is `DiscordWebhookPayload`. Here's a basic example of how to create one:

```csharp
using Hooki.Discord.Models;

var payload = new DiscordWebhookPayload
{
    Username = "My Webhook",
    AvatarUrl = "https://example.com/avatar.png",
    Content = "Hello, Discord!"
};
```

## Adding Embeds

Embeds are rich content blocks that can contain various elements. Here's how to add an embed:

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Username = "My Webhook",
    Embeds = new List<DiscordEmbed>
    {
        new DiscordEmbed
        {
            Title = "My Embed Title",
            Description = "This is a description of the embed",
            Color = 3447003 // Blue color in decimal
        }
    }
};
```

### Embed Author

You can add author information to an embed:

```csharp
new DiscordEmbed
{
    Author = new DiscordEmbedAuthor
    {
        Name = "Alertu",
        Url = "https://alertu.io",
        IconUrl = "https://example.com/logo.png"
    },
    // ... other embed properties
}
```

### Embed Fields

Fields are useful for displaying key-value pairs of information:

```csharp
new DiscordEmbed
{
    // ... other embed properties
    Fields = new List<DiscordEmbedField>
    {
        new DiscordEmbedField { Name = "Field 1", Value = "Value 1", Inline = true },
        new DiscordEmbedField { Name = "Field 2", Value = "Value 2", Inline = true }
    }
}
```

### Embed Images

Embeds support thumbnails and images. You can provide these images in two ways:

1. Reference an attachment:

```csharp
new DiscordEmbed
{
    Title = "Test Embed Title",
    Description = "Test Embed Description",
    Thumbnail = new DiscordEmbedThumbnail
    {
        Url = "attachment://hooki-icon.png"
    },
    Image = new DiscordEmbedImage
    {
        Url = "attachment://hooki-icon.png"
    }
}
```

2. Provide a direct URL to a public image:

```csharp
new DiscordEmbed
{
    Title = "Test Embed Title",
    Description = "Test Embed Description",
    Thumbnail = new DiscordEmbedThumbnail
    {
        Url = "https://example.com/thumbnail.png"
    },
    Image = new DiscordEmbedImage
    {
        Url = "https://example.com/image.png"
    }
}
```

## Polls

Polls are a great way to gather feedback from Discord server members automatically. Here's how to create a poll:

```csharp
var pollPayload = new DiscordWebhookPayload
{
    Poll = new DiscordPollCreateRequest
    {
        Question = new DiscordPollMedia
        {
            Text = "What is your favorite TV show?",
        },
        Duration = 24,
        AllowMultiSelect = true,
        Answers = new List<DiscordPollAnswer>
        {
            new DiscordPollAnswer
            {
                AnswerId = 1,
                PollMedia = new DiscordPollMedia
                {
                    Text = "Penguin",
                    Emoji = new DiscordEmoji { Name = "🐧" }
                }
            },
            // ... more answers
        }
    }
};
```

**Note:** Emojis cannot be used in Questions.

## Attachments and Files

### Multipart/form-data

When using attachments or files, you need to use multipart/form-data as the content for the webhook request. The `MultipartContent` property on the `DiscordWebhookPayload` class builds this for you:

```csharp
await _httpClient.PostAsync(url, discordPayload.MultipartContent);
```

### Attachments

To use attachments on their own:

```csharp
var payload = new DiscordWebhookPayload
{
    Content = "This is a test discord webhook payload",
    Attachments = new List<DiscordAttachment>
    {
        new DiscordAttachment
        {
            Id = DiscordSnowflakeId,
            FileName = TestImageFileName,
            ContentType = "image/png",
            Height = 128,
            Width = 128,
            Size = 19251,
            Content = GetTestImageBytes() // Implement this method to return your image bytes
        }
    }
};
```

### Using Files with Attachments

To use files alongside attachments:

```csharp
var payload = new DiscordWebhookPayload
{
    Content = "Test Content",
    Embeds = new List<DiscordEmbed>
    {
        new DiscordEmbed
        {
            Title = "Test Embed Title",
            Description = "Test Embed Description",
            Thumbnail = new DiscordEmbedThumbnail
            {
                Url = "attachment://hooki-icon.png"
            },
            Image = new DiscordEmbedImage
            {
                Url = "attachment://hooki-icon.png"
            }
        }
    },
    Attachments = new List<DiscordAttachment>
    {
        new DiscordAttachment
        {
            Id = DiscordSnowflakeId,
            Description = "Hooki Logo",
            FileName = "hooki-icon.png",
            Height = 128,
            Width = 128
        }
    },
    Files = new List<DiscordFileContent>
    {
        new DiscordFileContent
        {
            SnowflakeId = "123456789",
            FileName = "hooki-icon.png",
            ContentType = "image/png",
            FileContents = GetImageBytes() // Implement this method to return the image bytes
        }
    }
};
```

## Complete Example

Here's a comprehensive example that puts it all together:

```csharp
var payload = new DiscordWebhookPayload
{
    Username = "Alert Webhook",
    AvatarUrl = "https://example.com/alert-avatar.png",
    Embeds = new List<DiscordEmbed>
    {
        new DiscordEmbed
        {
            Author = new DiscordEmbedAuthor
            {
                Name = "AlertSystem",
                Url = "https://alertsystem.com",
                IconUrl = "https://example.com/alert-icon.png"
            },
            Title = "New Alert Triggered",
            Description = "[**View Alert**](https://alertsystem.com/alert/123) | [**View in Dashboard**](https://alertsystem.com/dashboard)",
            Color = 3066993, // Green color in decimal
            Fields = new List<DiscordEmbedField>
            {
                new DiscordEmbedField { Name = "Alert Type", Value = "CPU Usage", Inline = true },
                new DiscordEmbedField { Name = "Severity", Value = "High", Inline = true },
                new DiscordEmbedField { Name = "Triggered At", Value = DateTime.Now.ToString("f"), Inline = false },
                new DiscordEmbedField { Name = "Affected Resources", Value = "web-server-01, web-server-02", Inline = false }
            }
        }
    }
};

// Serialize into JSON
var jsonString = payload.Serialize();
```

Please make sure to use the extension available on the `DiscordWebhookPayload`, `MsTeamsWebhookPayload` and `SlackWebhookPayload` classes to serialize the payload into JSON using Hooki's settings for convenience and consistency.

```csharp
// Build your payload with what you want to send
var payload = new DiscordWebhookPayload();

// Serialize your payload into JSON ready to send
var jsonString = payload.Serialize();
```

## Markdown Styling in Discord Webhooks

Discord supports a subset of markdown formatting in webhook messages. Here are some common markdown techniques:

| Effect | Markdown | Example |
|--------|----------|---------|
| Italics | `*Italic*` | *Italic* |
| Bold | `**Bold**` | **Bold** |
| Bold italics | `***Bold Italic***` | ***Bold Italic*** |
| Strike-through | `~~Strike-through~~` | ~~Strike-through~~ |
| Links | `[Microsoft](https://www.microsoft.com)` | [Microsoft](https://www.microsoft.com) |
| Headings | `# Heading` through `###### Heading` | Varies from `<h1>` to `<h6>` |
| Bulleted lists | `* List item` or `- List item` | • List item |

## Best Practices and Limitations

1. Provide a value for at least one of: `Content`, `Embeds`, or `File` in the `DiscordWebhookPayload`.
2. The `Color` property in `DiscordEmbed` should be a decimal representation of a hexadecimal color code. You can use this [Color tool](https://www.mathsisfun.com/hexadecimal-decimal-colors.html) to convert a hexadecimal color into it's decimal value.
3. You can add up to 10 embeds per message.
4. The total size of all embeds in a message must not exceed 6000 characters.
5. Respect Discord's rate limits when sending webhooks.
6. File upload limit applies to all files in a request. The default limit is 25 MiB, but it can vary based on the guild's boost tier.

## Additional Resources

1. [Example of a Discord webhook](https://birdie0.github.io/discord-webhooks-guide/discord_webhook.html)
2. [Discord webhook payload documentation](https://discord.com/developers/docs/resources/webhook#execute-webhook)
3. [Discord API Rate Limits](https://discord.com/developers/docs/topics/rate-limits)