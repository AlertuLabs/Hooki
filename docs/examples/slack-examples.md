# Slack Examples

![plot](../screenshots/slack-example-screenshot.png)

```csharp
using Hooki.Slack.Models;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

return new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackHeaderBlock
        {
            Text = new SlackTextObject
            {
                Type = TextObjectTypes.PlainText,
                Text = $"Slack Webhook using Slack Block Kit"
            }
        },
        new SlackSectionBlock
        {
            Fields =
            [
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Organization Name:*\nTest Organization Name" },
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Project Name:*\nTest Project Name" },
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Cloud Provider:*\nAzure Name" },
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Resources:*\ntest-redis, test-postgreSQL" }
            ]
        },
        new SlackSectionBlock
        {
            Fields =
            [
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Severity:*\nCritical" },
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Status:*\nOpen" },
                new SlackTextObject { Type = TextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString("f")}" }
            ]
        },
        new SlackSectionBlock
        {
            Text = new SlackTextObject
            {
                Type = TextObjectType.Markdown,
                Text = $"*Summary:*\nTesting Slack Webhook"
            }
        },
        new SlackActionBlock
        {
            Elements =
            [
                new SlackButtonElement
                {
                    Text = new SlackTextObject
                    {
                        Type = TextObjectType.PlainText,
                        Text = "View in Alertu"
                    },
                    Url = appUrl,
                    Style = "primary"
                },

                new SlackButtonElement
                {
                    Text = new SlackTextObject
                    {
                        Type = TextObjectType.PlainText,
                        Text = $"View in Azure"
                    },
                    Url = alert.CloudUrl
                }
            ]
        }
    }
};
```

```csharp
var payload = new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackVideoBlock
        {
            Description = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "Test Description"
            },
            AltText = "Walking on a dream",
            VideoUrl = "https://www.youtube.com/embed/8876OZV_Yy0?feature=oembed&autoplay=1",
            ThumbnailUrl = "https://i.ytimg.com/vi/8876OZV_Yy0/hqdefault.jpg",
            Title = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "Test Video Title"
            }
        }
    }
};
```

```csharp
var payload = new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackInputBlock
        {
            Label = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "Email"
            },
            Element = new SlackEmailInputElement
            {
                Placeholder = new SlackTextObject
                {
                    Type = SlackTextObjectType.PlainText,
                    Text = "My Email Address"
                }
            }
        }
    }
};
```

```csharp
var payload = new SlackWebhookPayload
{
    Blocks = new List<SlackBlock>
    {
        new SlackImageBlock
        {
            AltText = "**Test image alt text**",
            ImageUrl = TestImageCloudUrl,
            Title = new SlackTextObject
            {
                Type = SlackTextObjectType.PlainText,
                Text = "Test Image Title"
            }
        }
    }
};
```