using FluentAssertions;
using Hooki.Discord.Builders;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class FileContentBuilderTests
{
    [Fact]
    public void Build_With_All_Properties_Returns_Correct_FileContent()
    {
        // Arrange
        var builder = new FileContentBuilder()
            .WithSnowflakeId("123456")
            .WithFileName("test.txt")
            .WithFileContents(new byte[] { 1, 2, 3 })
            .WithContentType("application/json");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.SnowflakeId.Should().Be("123456");
        result.FileName.Should().Be("test.txt");
        result.FileContents.Should().BeEquivalentTo(new byte[] { 1, 2, 3 });
        result.ContentType.Should().Be("application/json");
    }
}
