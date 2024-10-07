# Guide: Creating Discord Webhook Payloads

This guide will walk you through using our library to create Discord webhook payloads. The library provides a set of Plain Old CLR Objects (POCOs) that correspond to the Discord webhook payload structure.

## Basic Structure

The main object you'll be working with is `DiscordWebhookPayload`. Here's a basic example of how to create one:

```csharp
using Hooki.Discord.Models;

vvar payload = new DiscordWebhookPayload
{
    Username = "My Webhook",
    AvatarUrl = "https://example.com/avatar.png",
    Content = "Hello, Discord!"
};
```

## Adding Embeds

Embeds are rich content blocks that can contain various elements. Embeds will contain most of your webhook payload content. Here's how to add an embed:

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Username = "My Webhook",
    Embeds = new List<Embed>
    {
        new Embed
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
using Hooki.Discord.Models.BuildingBlocks;

new Embed
{
    Author = new EmbedAuthor
    {
        Name = "Alertu",
        Url = "https://alertu.io",
        IconUrl =  Logos.TestLogoUrl
    },
    // ... other embed properties
}
```

### Embed Fields

Fields are useful for displaying key-value pairs of information:

```csharp
using Hooki.Discord.Models.BuildingBlocks;

new Embed
{
    // ... other embed properties
    Fields = new List<EmbedField>
    {
        new EmbedField { Name = "Field 1", Value = "Value 1", Inline = true },
        new EmbedField { Name = "Field 2", Value = "Value 2", Inline = true }
    }
}
```

### Embed Images

Embeds support thumbnails and images. There are two ways to provide these images:

1. Reference an attachment by using the `attachment://` prefix followed by the `FileName` of the attachment.

```csharp
using Hooki.Discord.Models.BuildingBlocks;

new Embed
{
    Title = "Test Embed Title",
    Description = "Test Embed Description",
    Thumbnail = new EmbedThumbnail
    {
        Url = $"attachment://hooki-icon.png"
    },
    Image = new EmbedImage
    {
        Url = $"attachment://hooki-icon.png"
    }
}
```

2. Provide the URL to the public image directly in the embed

```csharp
using Hooki.Discord.Models.BuildingBlocks;

new Embed
{
    Title = "Test Embed Title",
    Description = "Test Embed Description",
    Thumbnail = new EmbedThumbnail
    {
        Url = "https://example-thumbnail-image.png"
    },
    Image = new EmbedImage
    {
        Url = "https://example-image.png"
    }
}
```

## Polls

Polls are a great way to automatically gather feedback from members in Discord servers

A poll needs to be created with at least one question and one answer. 

**Note:** Emojis cannot be used in Questions

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var pollPayload = new DiscordWebhookPayload
{
    Poll = new PollCreateRequest
    {
        Question = new PollMedia
        {
            Text = "What is your favorite TV show?",
        },
        Duration = 24,
        AllowMultiSelect = true,
        Answers = new List<PollAnswer>
        {
            new PollAnswer
            {
                AnswerId = 1,
                PollMedia = new PollMedia
                {
                    Text = "Penguin",
                    Emoji = new Emoji { Name = "🐧" }
                }
            },
            new PollAnswer
            {
                AnswerId = 2,
                PollMedia = new PollMedia
                {
                    Text = "Game of Thrones",
                    Emoji = new Emoji { Name = "❄️" }
                }
            },
            new PollAnswer
            {
                AnswerId = 3,
                PollMedia = new PollMedia
                {
                    Text = "Breaking Bad",
                    Emoji = new Emoji { Name = "🧪" }
                }
            }
        }
    }
};
```

## Attachments and Files

To use attachments or files, you need to provide a `SnowflakeId` for the attachment or file, a `FileName` for the attachment or file, and a `FileContents` for the attachment or file.

When using attachments or files, you need to use multipart/form-data as the content for the webhook request. This is because attachments and files are sent as binary data, and the webhook payload is sent as a form-data.

### Multipart/form-data

When using Multipart/form-data, you can use the `MultipartContent` property on the `DiscordWebhookPayload` class. This property builds the `Multipart/form-data` content for you, using the attachments, files and the message body you provided in the `PayloadJson` property. Sending a Discord webhook with `Multipart/form-data` is as simple as:

```csharp
_httpClient.PostAsync(url, discordPayload.MultipartContent);
```

### Attachments

You can use attachments on their own by providing a `SnowflakeId` for the attachment, a `FileName` for the attachment, `ContentType` and a `FileContents` for the attachment.

`Height`, `Size` and `Width` are optional. These properties are used to specify the dimensions of the attachment.

**Note:** When using attachments without files, you need to specify the content for each attachment

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Content = "This is a test discord webhook payload",
    Attachments = new List<Attachment>
    {
        new Attachment
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

Files can be provided alongside attachments making it convenient to use a single file for multiple attachments.

1. Add Files to the payload containing the `SnowflakeId`, `FileName`, `ContentType` and `FileContents`.
2. Add Attachments to the payload containing the `SnowflakeId` and `FileName`. The `FileName` needs to match the `FileName` of the file you want to attach.
3. You can reference these attachments in your embeds by using the `attachment://` prefix followed by the `FileName` of the attachment.

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Content = "Test Content",
    Embeds = new List<Embed>
    {
        new Embed
        {
            Title = "Test Embed Title",
            Description = "Test Embed Description",
            Thumbnail = new EmbedThumbnail
            {
                Url = $"attachment://hooki-icon.png"
            },
            Image = new EmbedImage
            {
                Url = $"attachment://hooki-icon.png"
            }
        }
    },
    Attachments = new List<Attachment>
    {
        new Attachment
        {
            Id = DiscordSnowflakeId,
            Description = "Hooki Logo",
            FileName = "hooki-icon.png",
            Height = 128,
            Width = 128
        }
    },
    Files = new List<FileContent>
    {
        new FileContent
        {
            SnowflakeId = "123456789",
            FileName = "hooki-icon.png",
            ContentType = "image/png",
            FileContents = GetImageBytes() // Implement this method to return the bytes for the image you want to attach
        }
    }
}
```

## Complete Example

Here's a more comprehensive example that puts it all together:

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Username = "Alert Webhook",
    AvatarUrl = "https://example.com/alert-avatar.png",
    Embeds = new List<Embed>
    {
        new Embed
        {
            Author = new EmbedAuthor
            {
                Name = "AlertSystem",
                Url = "https://alertsystem.com",
                IconUrl = "https://example.com/alert-icon.png"
            },
            Title = "New Alert Triggered",
            Description = "[**View Alert**](https://alertsystem.com/alert/123) | [**View in Dashboard**](https://alertsystem.com/dashboard)",
            Color = 3066993, // Green color in decimal
            Fields = new List<EmbedField>
            {
                new EmbedField { Name = "Alert Type", Value = "CPU Usage", Inline = true },
                new EmbedField { Name = "Severity", Value = "High", Inline = true },
                new EmbedField { Name = "Triggered At", Value = DateTime.Now.ToString("f"), Inline = false },
                new EmbedField { Name = "Affected Resources", Value = "web-server-01, web-server-02", Inline = false }
            }
        }
    }
};
```

## Markdown Styling in Discord Webhooks

Discord supports a subset of markdown formatting in webhook messages, allowing you to style your text for better readability and emphasis. Here are some common markdown techniques you can use:

### Text Formatting

1. **Bold**: Surround text with double asterisks or double underscores
   ```
   **bold text** or __bold text__
   ```

2. *Italic*: Surround text with single asterisks or single underscores
   ```
   *italic text* or _italic text_
   ```

3. ***Bold Italic***: Combine bold and italic
   ```
   ***bold italic*** or **_bold italic_** or __*bold italic*__
   ```

4. ~~Strikethrough~~: Surround text with double tildes
   ```
   ~~strikethrough~~
   ```

5. `Inline code`: Surround text with backticks
   ```
   `inline code`
   ```

### Code Blocks

For multi-line code blocks, use triple backticks:

```
​```
Multi-line
code block
​```
```

You can also specify the language for syntax highlighting:

```
​```python
def hello_world():
    print("Hello, Discord!")
​```
```

### Links

Create links using square brackets for the text and parentheses for the URL:
```
[Visit Discord](https://discord.com)
```

### Lists

Unordered lists use asterisks, plus signs, or hyphens:
```
* Item 1
* Item 2
* Item 3
```

Ordered lists use numbers:
```
1. First item
2. Second item
3. Third item
```

### Quotes

Use the greater-than symbol for quotes:
```
> This is a quote
```

### Example in Code

Here's how you might use markdown styling in your webhook payload:

```csharp
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

var payload = new DiscordWebhookPayload
{
    Username = "Alertu Webhook",
    AvatarUrl = "https://example.com/alert-avatar.png",
    Embeds = new List<Embed>
    {
        new Embed
        {
            Author = new EmbedAuthor
            {
                Name = "Alertu-system",
                Url = "https://alertsystem.com",
                IconUrl = "https://example.com/alert-icon.png"
            },
            Title = "**New Alert Triggered**",
            Description = $"[**View in AlertSystem**](https://alertsystem.com) | [**View in Azure**](https://portal.azure.com)",
            Color = 15158332, // Red color in decimal
            Fields = new List<EmbedField>
            {
                new EmbedField { Name = "**Summary**", Value = $"```Test Summary```", Inline = false },
                new EmbedField { Name = "Organization", Value = $"*Test Organization*", Inline = true },
                new EmbedField { Name = "Project", Value = $"*Test Project*", Inline = true },
                new EmbedField { Name = "Cloud Provider", Value = $"`Azure`", Inline = true },
                new EmbedField { Name = "Resources", Value = $"• test-redis\n• test-postgreSQL", Inline = false },
                new EmbedField { Name = "Severity", Value = $"**Critical**", Inline = true },
                new EmbedField { Name = "Status", Value = $"**Open**", Inline = true },
                new EmbedField { Name = "Triggered At", Value = $"_{DateTimeOffset.UtcNow.ToString("f")}_", Inline = true },
                new EmbedField { Name = "Resolved At", Value = $"_{DateTimeOffset.UtcNow.ToString("f")}_", Inline = true }
            }
        }
    }
};
```

Remember that while markdown can enhance readability, it's important to use it judiciously to maintain a clean and professional appearance in your webhook messages.

## Notes

1. Ensure that you provide a value for at least one of: `Content`, `Embeds`, or `File` in the `DiscordWebhookPayload`.
2. The `Color` property in `Embed` should be a decimal representation of a hexadecimal color code.
3. You can add up to 10 embeds per message.
4. The total size of all embeds in a message must not exceed 6000 characters.
5. Remember to respect Discord's rate limits when sending webhooks.
6. File upload some limit applies to all files in a request (rather than each individual file). Limit depends on the boost tier of your guild but the default is `25 MiB` by default.

## Links

1. [Good example of a Discord webhook](https://birdie0.github.io/discord-webhooks-guide/discord_webhook.html)

2. [Discord webhook payload documentation](https://discord.com/developers/docs/resources/webhook#execute-webhook)