using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Models.Actions;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests
{
    public class SectionBuilderTests
    {
        private const string Title = "Test Section";
        private const string ActivityImage = "https://example.com/activity.jpg";
        private const string ActivityTitle = "Activity Title";
        private const string ActivitySubtitle = "Activity Subtitle";
        private const string ActivityText = "Activity Text";
        private const string HeroImageUrl = "https://example.com/hero.jpg";
        private const string HeroImageTitle = "Hero Image";
        private const string Text = "Section Text";
        private const string FactName = "Fact Name";
        private const string FactValue = "Fact Value";
        private const string ImageUrl = "https://example.com/image.jpg";
        private const string ImageTitle = "Image Title";
        
        private const string Uri = "https://example.com";
        private const string Name = "Fetch";

        [Fact]
        public void Build_With_All_Properties_Returns_Correct_Section()
        {
            // Arrange
            var builder = new SectionBuilder()
                .WithTitle(Title)
                .WithStartGroup(true)
                .WithActivityImage(ActivityImage)
                .WithActivityTitle(ActivityTitle)
                .WithActivitySubtitle(ActivitySubtitle)
                .WithActivityText(ActivityText)
                .WithHeroImage(i => i.WithImageUrl(HeroImageUrl).WithTitle(HeroImageTitle))
                .WithText(Text)
                .AddFact(f => f.WithName(FactName).WithValue(FactValue))
                .AddImage(i => i.WithImageUrl(ImageUrl).WithTitle(ImageTitle))
                .AddOpenUriAction(Name, Uri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(Title);
            result.StartGroup.Should().BeTrue();
            result.ActivityImage.Should().Be(ActivityImage);
            result.ActivityTitle.Should().Be(ActivityTitle);
            result.ActivitySubtitle.Should().Be(ActivitySubtitle);
            result.ActivityText.Should().Be(ActivityText);
            result.HeroImage.Should().NotBeNull();
            result.HeroImage!.ImageUrl.Should().Be(HeroImageUrl);
            result.HeroImage.Title.Should().Be(HeroImageTitle);
            result.Text.Should().Be(Text);
            result.Facts.Should().ContainSingle();
            result.Facts![0].Name.Should().Be(FactName);
            result.Facts[0].Value.Should().Be(FactValue);
            result.Images.Should().ContainSingle();
            result.Images![0].ImageUrl.Should().Be(ImageUrl);
            result.Images[0].Title.Should().Be(ImageTitle);
            result.PotentialActions.Should().ContainSingle();
            result.PotentialActions![0].Should().BeOfType<OpenUriAction>()
                .Which.Name.Should().Be(Name);
        }

        [Fact]
        public void Build_With_Minimum_Properties_Returns_Correct_Section()
        {
            // Arrange
            var builder = new SectionBuilder()
                .WithTitle(Title);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(Title);
            result.StartGroup.Should().BeNull();
            result.ActivityImage.Should().BeNull();
            result.ActivityTitle.Should().BeNull();
            result.ActivitySubtitle.Should().BeNull();
            result.ActivityText.Should().BeNull();
            result.HeroImage.Should().BeNull();
            result.Text.Should().BeNull();
            result.Facts.Should().BeNull();
            result.Images.Should().BeNull();
            result.PotentialActions.Should().BeNull();
        }

        [Fact]
        public void Build_With_NoProperties_Returns_Empty_Section()
        {
            // Arrange
            var builder = new SectionBuilder();

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().BeNull();
            result.StartGroup.Should().BeNull();
            result.ActivityImage.Should().BeNull();
            result.ActivityTitle.Should().BeNull();
            result.ActivitySubtitle.Should().BeNull();
            result.ActivityText.Should().BeNull();
            result.HeroImage.Should().BeNull();
            result.Text.Should().BeNull();
            result.Facts.Should().BeNull();
            result.Images.Should().BeNull();
            result.PotentialActions.Should().BeNull();
        }
    }
}