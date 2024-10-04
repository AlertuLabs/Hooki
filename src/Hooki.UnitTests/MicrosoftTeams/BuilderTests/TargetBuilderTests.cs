using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class TargetBuilderTests
    {
        private const string ValidUri = "https://example.com";
        
        private const OperatingSystemType DefaultOperatingSystem = OperatingSystemType.Default;
        private const OperatingSystemType CustomOperatingSystem = OperatingSystemType.Android;

        [Fact]
        public void Build_With_All_Properties_Returns_Correct_Target()
        {
            // Arrange
            var builder = new TargetBuilder()
                .WithOperatingSystem(CustomOperatingSystem)
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.OperatingSystem.Should().Be(CustomOperatingSystem);
            result.Uri.Should().Be(ValidUri);
        }

        [Fact]
        public void Build_With_Only_Uri_Returns_Target_With_Default_OS()
        {
            // Arrange
            var builder = new TargetBuilder()
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.OperatingSystem.Should().Be(DefaultOperatingSystem);
            result.Uri.Should().Be(ValidUri);
        }

        [Fact]
        public void Build_Without_Uri_Throws_InvalidOperationException()
        {
            // Arrange
            var builder = new TargetBuilder()
                .WithOperatingSystem(CustomOperatingSystem);

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Uri is required for Target.");
        }

        [Theory]
        [InlineData(OperatingSystemType.IOS)]
        [InlineData(OperatingSystemType.Android)]
        [InlineData(OperatingSystemType.Windows)]
        public void Build_With_Different_OS_Types_Returns_Correct_Target(OperatingSystemType osType)
        {
            // Arrange
            var builder = new TargetBuilder()
                .WithOperatingSystem(osType)
                .WithUri(ValidUri);

            // Act
            var result = builder.Build();

            // Assert
            result.Should().NotBeNull();
            result.OperatingSystem.Should().Be(osType);
            result.Uri.Should().Be(ValidUri);
        }
    }