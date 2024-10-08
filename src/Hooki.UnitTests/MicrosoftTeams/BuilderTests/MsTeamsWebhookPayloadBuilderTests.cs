using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Models.Actions;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class MsTeamsWebhookPayloadBuilderTests
    {
        private const string CorrelationId = "test-correlation-id";
        private const string Originator = "test-originator";
        private const string Title = "Test Title";
        private const string Text = "Test Text";
        private const string ThemeColor = "#FF0000";
        private const string Summary = "Test Summary";
        private const string ExpectedActor = "test-actor";
        private const string SectionTitle = "Test Section";
        
        private const string Uri = "https://example.com";
        private const string Name = "Test Action";

        [Fact]
        public void Build_With_All_Properties_Returns_Correct_MessageCard()
        {
            // Arrange
            var builder = new MsTeamsWebhookPayloadBuilder()
                .WithCorrelationId(CorrelationId)
                .WithOriginator(Originator)
                .WithTitle(Title)
                .WithText(Text)
                .WithThemeColor(ThemeColor)
                .WithSummary(Summary)
                .AddExpectedActor(ExpectedActor)
                .WithHiddenOriginalBody(true)
                .AddSection(s => s.WithTitle(SectionTitle))
                .AddOpenUriAction(Name, Uri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.CorrelationId.Should().Be(CorrelationId);
            result.Originator.Should().Be(Originator);
            result.Title.Should().Be(Title);
            result.Text.Should().Be(Text);
            result.ThemeColor.Should().Be(ThemeColor);
            result.Summary.Should().Be(Summary);
            result.ExpectedActors.Should().ContainSingle().Which.Should().Be(ExpectedActor);
            result.HideOriginalBody.Should().BeTrue();
            result.Sections.Should().ContainSingle().Which.Title.Should().Be(SectionTitle);
            result.PotentialActions.Should().ContainSingle().Which.Should().BeOfType<MsTeamsOpenUriAction>()
                .Which.Name.Should().Be(Name);
        }

        [Fact]
        public void Build_With_Minimum_Properties_Returns_Correct_MessageCard()
        {
            // Arrange
            var builder = new MsTeamsWebhookPayloadBuilder()
                .WithText(Text);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.Text.Should().Be(Text);
            result.CorrelationId.Should().BeNull();
            result.Originator.Should().BeNull();
            result.Title.Should().BeNull();
            result.ThemeColor.Should().BeNull();
            result.Summary.Should().BeNull();
            result.ExpectedActors.Should().BeNull();
            result.HideOriginalBody.Should().BeNull();
            result.Sections.Should().BeNull();
            result.PotentialActions.Should().BeNull();
        }

        [Fact]
        public void Build_Without_Text_Or_Summary_Throws_InvalidOperationException()
        {
            // Arrange
            var builder = new MsTeamsWebhookPayloadBuilder()
                .WithTitle(Title);

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Either Text or Summary must be provided.");
        }
    }