namespace Hooki.Discord.Models.BuildingBlocks;

public class FileContent
{
    public required string SnowflakeId { get; set; }
    public required string FileName { get; set; }
    
    public required byte[] FileContents { get; set; }
    
    public required string ContentType { get; set; }
}