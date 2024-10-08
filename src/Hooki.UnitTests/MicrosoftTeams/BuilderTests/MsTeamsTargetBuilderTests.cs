using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class MsTeamsTargetBuilderTests
    {
        private const string ValidUri = "https://example.com";
        
        private const MsTeamsOperatingSystemType DefaultOperatingSystem = MsTeamsOperatingSystemType.Default;
        private const MsTeamsOperatingSystemType CustomOperatingSystem = MsTeamsOperatingSystemType.Android;

        [Fact]
        public void Build_With_All_Properties_Returns_Correct_Target()
        {
            // Arrange
            var builder = new MsTeamsTargetBuilder()
                .WithOperatingSystem(CustomOperatingSystem)
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.MsTeamsOperatingSystem.Should().Be(CustomOperatingSystem);
            result.Uri.Should().Be(ValidUri);
        }

        [Fact]
        public void Build_With_Only_Uri_Returns_Target_With_Default_OS()
        {
            // Arrange
            var builder = new MsTeamsTargetBuilder()
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.MsTeamsOperatingSystem.Should().Be(DefaultOperatingSystem);
            result.Uri.Should().Be(ValidUri);
        }

        [Fact]
        public void Build_Without_Uri_Throws_InvalidOperationException()
        {
            // Arrange
            var builder = new MsTeamsTargetBuilder()
                .WithOperatingSystem(CustomOperatingSystem);

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Uri is required for Target.");
        }

        [Theory]
        [InlineData(MsTeamsOperatingSystemType.IOS)]
        [InlineData(MsTeamsOperatingSystemType.Android)]
        [InlineData(MsTeamsOperatingSystemType.Windows)]
        public void Build_With_Different_OS_Types_Returns_Correct_Target(MsTeamsOperatingSystemType osType)
        {
            // Arrange
            var builder = new MsTeamsTargetBuilder()
                .WithOperatingSystem(osType)
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.MsTeamsOperatingSystem.Should().Be(osType);
            result.Uri.Should().Be(ValidUri);
        }
    }