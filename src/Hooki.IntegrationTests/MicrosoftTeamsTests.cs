using Hooki.MicrosoftTeams.Extensions;
using IntegrationTests.Config;
using IntegrationTests.Enums;
using System.Net;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace IntegrationTests;

public class MicrosoftTeamsTests(HttpClientFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task When_Sending_A_Valid_MicrosoftTeams_MessageCard_Webhook_Then_Return_200()
    {
        // Arrange
        var messageCard = MessageCardExtensions.BuildDMessageCard(builder => builder
            .WithThemeColor("0ea4e9")
            .WithSummary("Test Summary")
            .AddSection(section => section
                .WithActivityTitle("**Azure Metric Alert triggered**")
                .WithActivitySubtitle($"**Severity - Critical | Status - Open**")
                .WithActivityText("Testing Webhooks")
                .WithActivityImage("https://res.cloudinary.com/deknqhm9k/image/upload/v1727617327/Social2_bvec22.png")
                .AddFact("Organization Name:", "Test Organization")
                .AddFact("Project Name:", "Test Project")
                .AddFact("Alert Group Name:", "Alert Group Name")
                .AddFact("Cloud Provider:", "Azure")
                .AddFact("Severity:", "Critical")
                .AddFact("Status:", "Open")
                .AddFact("Affected Resources:", string.Join(", ", "test-redis", "test-postgreSQL"))
                .AddFact("Triggered At:", DateTimeOffset.UtcNow.ToString("f"))
                .AddFact("Resolved At:", DateTimeOffset.UtcNow.AddMinutes(5).ToString("f"))
            )
            .AddOpenUriAction("View in Alertu", "https://alertu.io")
            .AddOpenUriAction($"View in Azure", "https://portal.azure.com")
            .Build());
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_A_Valid_MessageCard_With_All_Action_Types_Then_Return_200()
    {
        var messageCard = MessageCardExtensions.BuildDMessageCard(builder => builder
            .WithThemeColor("0ea4e9")
            .WithSummary("Test All Action Types")
            .AddSection(section => section
                .WithActivityTitle("Testing All Action Types")
            )
            .AddOpenUriAction("Open URI", "https://example.com")
            .AddHttpPostAction("HTTP POST", "https://example.com/api", "{\"key\":\"value\"}", "application/json", new List<Header>())
            .AddActionCardAction("Action Card", [], [])
            .AddInvokeAddInCommandAction("Invoke Add-In", "add-in-id", "command-id", null)
            .Build());
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_A_Valid_Minimal_MessageCard_Then_Return_200()
    {
        var messageCard = MessageCardExtensions.BuildDMessageCard(builder => builder
            .WithText("Test All Action Types")
            .Build());
        
        var response = await SendWebhookPayloadAsync(PlatformTypes.MicrosoftTeams, messageCard);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}