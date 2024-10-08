using System.Net;
using Hooki.Slack.Enums;
using Hooki.Slack.Models;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;
using IntegrationTests.Config;
using IntegrationTests.Enums;

namespace IntegrationTests;

public class SlackTests : IntegrationTestBase
{
    public SlackTests(HttpClientFixture fixture) : base(fixture) { }

    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Context_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackContextBlock
                {
                    Elements = new List<ISlackContextBlockElement>
                    {
                        new SlackImageElement { ImageUrl = TestImageCloudUrl, AltText = "Image" },
                        new SlackTextObject
                            { Type = SlackTextObjectType.PlainText, Text = "This is text for a context block element" }
                    }
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Action_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackActionBlock
                {
                    Elements = new List<ISlackActionBlockElement>
                    {
                        new SlackButtonElement { SlackText = new SlackTextObject{Type = SlackTextObjectType.PlainText ,Text = "Button Text"}},
                        new SlackCheckboxElement { Options =
                            [
                                new SlackOptionObject
                                {
                                    SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Choice Text" },
                                    Value = "Choice Value"
                                }
                            ]
                        }
                    }
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Header_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackHeaderBlock
                {
                    SlackText = new SlackTextObject
                    {
                        Type = SlackTextObjectType.PlainText,
                        Text = "Header Text"
                    }
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Image_Block_Then_Return_200()
    {
        // Arrange
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
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Input_Block_Then_Return_200()
    {
        // Arrange
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
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_RichText_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Organization Name:*\n Test Organization" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Project Name:*\n Test Project" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Cloud Provider:*\n Test Cloud Provider" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Severity:*\n Critical" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Status:*\n Closed" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SlackSectionBlock
                {
                    Text = new SlackTextObject
                    {
                        Type = SlackTextObjectType.Markdown,
                        Text = "*Summary:*\n doodoo"
                    }
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Section_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Organization Name:*\n Test Organization" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Project Name:*\n Test Project" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Cloud Provider:*\n Test Cloud Provider" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Severity:*\n Critical" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = "*Status:*\n Closed" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SlackSectionBlock
                {
                    Text = new SlackTextObject
                    {
                        Type = SlackTextObjectType.Markdown,
                        Text = "*Summary:*\n doodoo"
                    }
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Video_Block_Then_Return_200()
    {
        // Arrange
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
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void When_Sending_A_Valid_Slack_Webhook_Payload_With_Simple_Layout_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<SlackBlock>
            {
                new SlackHeaderBlock
                {
                    SlackText = new SlackTextObject
                    {
                        Type = SlackTextObjectType.PlainText,
                        Text = "Header Text"
                    }
                },
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Organization Name:*\n Test Organization" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Project Name:*\n Test Project" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Cloud Provider:*\n Test Cloud Provider" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SlackSectionBlock
                {
                    Fields =
                    [
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Severity:*\n Critical" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Status:*\n Closed" },
                        new SlackTextObject { Type = SlackTextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SlackSectionBlock
                {
                    Text = new SlackTextObject
                    {
                        Type = SlackTextObjectType.Markdown,
                        Text = $"*Summary:*\n doodoo"
                    }
                },
                new SlackActionBlock
                {
                    Elements =
                    [
                        new SlackButtonElement
                        {
                            SlackText = new SlackTextObject
                            {
                                Type = SlackTextObjectType.PlainText,
                                Text = "View in Alertu"
                            },
                            Url = "https://example.com",
                            Style = "primary"
                        },
                        new SlackButtonElement
                        {
                            SlackText = new SlackTextObject
                            {
                                Type = SlackTextObjectType.PlainText,
                                Text = "View in Azure"
                            },
                            Url = "https://portal.azure.com"
                        }
                    ]
                }
            }
        };
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}