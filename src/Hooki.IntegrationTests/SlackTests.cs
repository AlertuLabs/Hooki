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

    /*[Fact]
    public async void When_Sending_A_Valid_Payload_With_Context_Block_Then_Return_200()
    {
        var payload = new SlackWebhookPayload
        {
            Blocks = new List<BlockBase>
            {
                new ContextBlock
                {
                    Elements = new ContextBlockElement[]
                    {
                        new ImageElement { ImageUrl = TestImageCloudUrl, AltText = "Image" },
                        new TextObject
                            { Type = TextObjectType.PlainText, Text = "This is text for a context block element" }
                    }
                }
            }
        };
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }*/
    
    [Fact]
    public async void When_Sending_A_Valid_Payload_With_Action_Block_Then_Return_200()
    {
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
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.Slack, payload);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}