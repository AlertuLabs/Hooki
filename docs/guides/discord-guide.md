# Guide: Creating Discord Webhook Payloads

This guide will walk you through using our library to create Discord webhook payloads. The library provides a set of Plain Old CLR Objects (POCOs) that correspond to the Discord webhook payload structure.

## Basic Structure

The main object you'll be working with is `DiscordWebhookPayload`. Here's a basic example of how to create one:

```csharp
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

## Embed Author

You can add author information to an embed:

```csharp
new Embed
{
    Author = new EmbedAuthor
    {
        Name = "Author Name",
        Url = "https://example.com/author",
        IconUrl = "https://example.com/author-icon.png"
    },
    // ... other embed properties
}
```

## Embed Fields

Fields are useful for displaying key-value pairs of information:

```csharp
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

## Complete Example

Here's a more comprehensive example that puts it all together:

```csharp
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

For more details on Discord's webhook structure and limitations, refer to the [official Discord documentation](https://discord.com/developers/docs/resources/webhook#execute-webhook).

## Links

1. [Good example of a Discord webhook](https://birdie0.github.io/discord-webhooks-guide/discord_webhook.html)

2. [Discord webhook payload documentation](https://discord.com/developers/docs/resources/webhook#execute-webhook)

3. [Discord embed object documentation](https://discord.com/developers/docs/resources/message#embed-object)