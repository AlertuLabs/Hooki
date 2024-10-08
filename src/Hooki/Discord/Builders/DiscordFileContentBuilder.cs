using System.Text.RegularExpressions;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public partial class DiscordFileContentBuilder
{
    private string? _snowflakeId;
    private string? _fileName;
    private byte[]? _fileContents;
    private string? _contentType;

    [GeneratedRegex(@"^[\w-\.]+$")]
    private static partial Regex FileNameRegex();

    public DiscordFileContentBuilder WithSnowflakeId(string snowflakeId)
    {
        _snowflakeId = snowflakeId;
        return this;
    }

    public DiscordFileContentBuilder WithFileName(string fileName)
    {
        if (!FileNameRegex().IsMatch(fileName))
            throw new ArgumentException("FileName must be ASCII alphanumeric with underscores, dashes, or dots.");
        _fileName = fileName;
        return this;
    }

    public DiscordFileContentBuilder WithFileContents(byte[] fileContents)
    {
        _fileContents = fileContents;
        return this;
    }

    public DiscordFileContentBuilder WithContentType(string contentType)
    {
        _contentType = contentType;
        return this;
    }

    public DiscordFileContent Build()
    {
        if (string.IsNullOrWhiteSpace(_snowflakeId))
            throw new InvalidOperationException("SnowflakeId is required for FileContent.");
        if (string.IsNullOrWhiteSpace(_fileName))
            throw new InvalidOperationException("FileName is required for FileContent.");
        if (_fileContents == null || _fileContents.Length == 0)
            throw new InvalidOperationException("FileContents are required for FileContent.");
        if (string.IsNullOrWhiteSpace(_contentType))
            throw new InvalidOperationException("ContentType is required for FileContent.");

        return new DiscordFileContent
        {
            SnowflakeId = _snowflakeId,
            FileName = _fileName,
            FileContents = _fileContents,
            ContentType = _contentType
        };
    }
}