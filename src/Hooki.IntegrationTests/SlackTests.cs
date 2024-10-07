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
    public async void When_Sending_A_Valid_Payload_With_Context_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new ContextBlock
                {
                    Elements = new List<IContextBlockElement>
                    {
                        new ImageElement { ImageUrl = TestImageCloudUrl, AltText = "Image" },
                        new TextObject
                            { Type = TextObjectType.PlainText, Text = "This is text for a context block element" }
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
    public async void When_Sending_A_Valid_Payload_With_Action_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new ActionBlock
                {
                    Elements = new List<IActionBlockElement>
                    {
                        new ButtonElement { Text = new TextObject{Type = TextObjectType.PlainText ,Text = "Button Text"}},
                        new CheckboxElement { Options =
                            [
                                new OptionObject
                                {
                                    Text = new TextObject { Type = TextObjectType.PlainText, Text = "Choice Text" },
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
    public async void When_Sending_A_Valid_Payload_With_Header_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new HeaderBlock
                {
                    Text = new TextObject
                    {
                        Type = TextObjectType.PlainText,
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
    public async void When_Sending_A_Valid_Payload_With_Image_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new ImageBlock
                {
                   AltText = "**Test image alt text**",
                   ImageUrl = TestImageCloudUrl,
                   Title = new TextObject
                   {
                       Type = TextObjectType.PlainText,
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
    public async void When_Sending_A_Valid_Payload_With_Input_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new InputBlock
                {
                   Label = new TextObject
                   {
                       Type = TextObjectType.PlainText,
                       Text = "Email"
                   },
                   Element = new EmailInputElement
                   {
                       Placeholder = new TextObject
                       {
                           Type = TextObjectType.PlainText,
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
    public async void When_Sending_A_Valid_Payload_With_RichText_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Organization Name:*\n Test Organization" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Project Name:*\n Test Project" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Cloud Provider:*\n Test Cloud Provider" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Severity:*\n Critical" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Status:*\n Closed" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SectionBlock
                {
                    Text = new TextObject
                    {
                        Type = TextObjectType.Markdown,
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
    public async void When_Sending_A_Valid_Payload_With_Section_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Organization Name:*\n Test Organization" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Project Name:*\n Test Project" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Cloud Provider:*\n Test Cloud Provider" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Severity:*\n Critical" },
                        new TextObject { Type = TextObjectType.Markdown, Text = "*Status:*\n Closed" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SectionBlock
                {
                    Text = new TextObject
                    {
                        Type = TextObjectType.Markdown,
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
    public async void When_Sending_A_Valid_Payload_With_Video_Block_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new VideoBlock
                {
                    Description = new TextObject
                    {
                        Type = TextObjectType.PlainText,
                        Text = "Test Description"
                    },
                    AltText = "Walking on a dream",
                    VideoUrl = "https://www.youtube.com/embed/8876OZV_Yy0?feature=oembed&autoplay=1",
                    ThumbnailUrl = "https://i.ytimg.com/vi/8876OZV_Yy0/hqdefault.jpg",
                    Title = new TextObject
                    {
                        Type = TextObjectType.PlainText,
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
    public async void When_Sending_A_Valid_Payload_With_Simple_Layout_Then_Return_200()
    {
        // Arrange
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new HeaderBlock
                {
                    Text = new TextObject
                    {
                        Type = TextObjectType.PlainText,
                        Text = "Header Text"
                    }
                },
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Organization Name:*\n Test Organization" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Project Name:*\n Test Project" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Cloud Provider:*\n Test Cloud Provider" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Resources:*\n test-redis, test-postgreSQL" }
                    ]
                },
                new SectionBlock
                {
                    Fields =
                    [
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Severity:*\n Critical" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Status:*\n Closed" },
                        new TextObject { Type = TextObjectType.Markdown, Text = $"*Triggered At:*\n{DateTimeOffset.UtcNow.ToString()}" }
                    ]
                },
                new SectionBlock
                {
                    Text = new TextObject
                    {
                        Type = TextObjectType.Markdown,
                        Text = $"*Summary:*\n doodoo"
                    }
                },
                new ActionBlock
                {
                    Elements =
                    [
                        new ButtonElement
                        {
                            Text = new TextObject
                            {
                                Type = TextObjectType.PlainText,
                                Text = "View in Alertu"
                            },
                            Url = "https://example.com",
                            Style = "primary"
                        },

                        new ButtonElement
                        {
                            Text = new TextObject
                            {
                                Type = TextObjectType.PlainText,
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