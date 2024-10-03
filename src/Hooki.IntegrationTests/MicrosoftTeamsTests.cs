using Hooki.MicrosoftTeams.Extensions;
using IntegrationTests.Config;
using IntegrationTests.Enums;
using System.Net;

namespace IntegrationTests;

public class MicrosoftTeamsTests : IntegrationTestBase
{
    public MicrosoftTeamsTests(HttpClientFixture fixture) : base(fixture) { }

    [Fact]
    public async Task When_Sending_A_Valid_MicrosoftTeams_MessageCard_Webhook_Then_Return_204()
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
}