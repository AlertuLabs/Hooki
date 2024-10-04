using IntegrationTests.Config;
using IntegrationTests.Enums;
using System.Net;
using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace IntegrationTests;

public class MicrosoftTeamsTests(HttpClientFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task When_Sending_A_Valid_MicrosoftTeams_MessageCard_Webhook_Then_Return_200()
    {
        // Arrange
        var messageCard = new MessageCardBuilder()
            .WithThemeColor("0ea4e9")
            .WithSummary("Test Summary")
            .AddSection(section => section
                .WithActivityTitle("**Azure Metric Alert triggered**")
                .WithActivitySubtitle($"**Severity - Critical | Status - Open**")
                .WithActivityText("Testing Webhooks")
                .WithActivityImage(TestImageCloudUrl)
                .AddFact(fact => fact
                        .WithName("Organization Name:")
                        .WithValue("Test Organization"))
                .AddFact(fact => fact
                    .WithName("Project Name:")
                    .WithValue("Test Project"))
                .AddFact(fact => fact
                    .WithName("Alert Group Name:")
                    .WithValue("Alert Group Name"))
                .AddFact(fact => fact
                    .WithName("Cloud Provider:")
                    .WithValue("Azure"))
                .AddFact(fact => fact
                    .WithName("Severity:")
                    .WithValue("Critical"))
                .AddFact(fact => fact
                    .WithName("Status:")
                    .WithValue("Open"))
                .AddFact(fact => fact
                    .WithName("Affected Resources:")
                    .WithValue(string.Join(", ", "test-redis", "test-postgreSQL")))
                .AddFact(fact => fact
                    .WithName("Triggered At:")
                    .WithValue(DateTimeOffset.UtcNow.ToString("f")))
                .AddFact(fact => fact
                    .WithName("Resolved At:")
                    .WithValue(DateTimeOffset.UtcNow.AddMinutes(5).ToString("f")))
            )
            .AddOpenUriAction("View in Alertu", "https://alertu.io")
            .AddOpenUriAction($"View in Azure", "https://portal.azure.com")
            .Build();
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_A_Valid_MessageCard_With_All_Action_Types_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithThemeColor("0ea4e9")
            .WithSummary("Test All Action Types")
            .AddSection(section => section
                .WithActivityTitle("Testing All Action Types")
            )
            .AddOpenUriAction("Open URI", "https://example.com")
            .AddHttpPostAction("HTTP POST", "https://example.com/api", "{\"key\":\"value\"}", "application/json", new List<Header>())
            .AddActionCardAction("Action Card", [], [])
            .AddInvokeAddInCommandAction("Invoke Add-In", "add-in-id", "command-id", null)
            .Build();
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_A_Valid_Minimal_MessageCard_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithText("Test All Action Types")
            .Build();
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_MessageCard_With_Multiple_Sections_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Multi-Section Card")
            .WithText("This card has multiple sections")
            .AddSection(section => section
                .WithTitle("Section 1")
                .WithText("Content of section 1")
                .AddFact(fact => fact.WithName("Fact 1").WithValue("Value 1"))
            )
            .AddSection(section => section
                .WithTitle("Section 2")
                .WithText("Content of section 2")
                .AddImage(image => image.WithImageUrl(TestImageCloudUrl).WithTitle("Sample Image"))
            )
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task When_Sending_MessageCard_With_HeroImage_And_ActivityDetails_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Card with Hero Image and Activity")
            .WithSummary("Testing HeroImage and Activity")
            .AddSection(section => section
                .WithHeroImage(image => image
                    .WithImageUrl(TestImageCloudUrl)
                    .WithTitle("Hero Image"))
                .WithActivityTitle("Important Activity")
                .WithActivitySubtitle("Subtitle for the activity")
                .WithActivityText("Detailed description of the activity")
                .WithActivityImage(TestImageCloudUrl)
            )
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task When_Sending_MessageCard_With_ActionCard_With_A_TextInput_And_DateInput_And_HttpPostAction_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Card with Complex Action Card")
            .WithText("This card demonstrates a complex Action Card")
            .AddActionCardAction("Fill Form", new List<InputBase>
                {
                    new TextInput 
                    { 
                        Id = "comment",
                        Title = "Input's title property",
                        IsMultiline = true 
                    },
                    new DateInput 
                    { 
                        Id = "date",
                        Title = "Select Date" 
                    }
                }, 
                new List<ActionBase>
                {
                    new HttpPostAction
                    {
                        Name = "Submit",
                        Target = PipedreamUrl,
                        Body = "comment={{comment.value}}&date={{date.value}}"
                    }
                })
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_MessageCard_With_ActionCard_With_A_MultiChoiceInput_And_HttpPostAction_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Card with Complex Action Card")
            .WithText("This card demonstrates a complex Action Card")
            .AddActionCardAction("Fill Form", new List<InputBase>
                {
                    new MultiChoiceInput
                    {
                        Id = "choice",
                        Title = "Select Options",
                        IsMultiSelect = true,
                        Choices =
                        [
                            new Choice { Display = "Option 1", Value = "1" },
                            new Choice { Display = "Option 2", Value = "2" },
                            new Choice { Display = "Option 3", Value = "3" }
                        ]
                    }
                },
                [
                    new HttpPostAction
                    {
                        Name = "Submit",
                        Target = PipedreamUrl,
                        Body = "choice={{choice.value}}"
                    }
                ])
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_MessageCard_With_ActionCard_With_An_OpenUriAction_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Card with Complex Action Card")
            .WithText("This card demonstrates a complex Action Card")
            .AddActionCardAction("Fill Form", null,
            [
                new OpenUriAction
                {
                    Name = "Open URI",
                    Targets = [new Target { OperatingSystem = OperatingSystemTypes.Default, Uri = "https://example.com" }]
                }
            ])
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task When_Sending_MessageCard_With_Facts_And_StartGroup_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Card with Various Facts and Start Group")
            .WithSummary("Employee Information....")
            .AddSection(section => section
                .WithTitle("Employee Information")
                .WithStartGroup(true)
                .AddFact(fact => fact.WithName("Name").WithValue("John Doe"))
                .AddFact(fact => fact.WithName("Employee ID").WithValue("EMP001"))
                .AddFact(fact => fact.WithName("Department").WithValue("IT"))
                .AddFact(fact => fact.WithName("Join Date").WithValue(DateTime.Now.AddYears(-2).ToString("d")))
                .AddFact(fact => fact.WithName("Performance").WithValue("Excellent"))
            )
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task When_Sending_MessageCard_With_Multiple_Images_And_Actions_Then_Return_200()
    {
        var messageCard = new MessageCardBuilder()
            .WithTitle("Product Showcase")
            .WithText("Check out our latest products!")
            .AddSection(section => section
                .AddImage(image => image.WithImageUrl(TestImageCloudUrl).WithTitle("Product 1"))
                .AddImage(image => image.WithImageUrl(TestImageCloudUrl).WithTitle("Product 2"))
                .AddImage(image => image.WithImageUrl(TestImageCloudUrl).WithTitle("Product 3")))
            .AddOpenUriAction("View Catalog", "https://example.com/catalog")
            .AddHttpPostAction("Request Info", "https://example.com/api/info", "{\"request\":\"info\"}", "application/json", new List<Header>())
            .Build();

        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}