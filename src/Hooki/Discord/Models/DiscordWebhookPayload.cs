using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Discord.Models.BuildingBlocks;
using Hooki.Utilities;

namespace Hooki.Discord.Models;

/// <summary>
/// Refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/webhook#execute-webhook
/// </summary>
public class DiscordWebhookPayload
{
    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("username")] public string? Username { get; set; }

    [JsonPropertyName("avatar_url")] public string? AvatarUrl { get; set; }

    [JsonPropertyName("tts")] public bool? Tts { get; set; }

    [JsonPropertyName("embeds")] public List<Embed>? Embeds { get; set; }

    [JsonPropertyName("allowed_mentions")] public AllowedMention? AllowedMentions { get; set; }

    /// <summary>
    /// We're not supporting message components at the moment.
    /// Please refer to our README to see our roadmap.
    /// In the meantime, you can use anonymous objects and refer to Discord's documentation for more details: https://discord.com/developers/docs/interactions/message-components#component-object
    /// </summary>
    [JsonPropertyName("components")] public List<object>? Components { get; set; }

    /// <summary>
    /// Files is not serialized JSON with the payload
    /// You can either use DiscordWebhookPayload.MultipartContent or you can implement the MultipartContent yourself
    /// Please refer to the discord documentation for more details: https://discord.com/developers/docs/reference#uploading-files
    /// </summary>
    [JsonIgnore] public List<FileContent>? Files { get; set; }

    [JsonPropertyName("payload_json")] public string? PayloadJson { get; set; }

    [JsonPropertyName("attachments")] public List<Attachment>? Attachments { get; set; }

    [JsonPropertyName("flags")] public int? Flags { get; set; }

    /// <summary>
    /// If ThreadName is provided, a thread with that name will be created in the channel if it doesn't already exist
    /// Requires the webhook channel to be a forum or media channel
    /// </summary>
    [JsonPropertyName("thread_name")] public string? ThreadName { get; set; }

    [JsonPropertyName("applied_tags")] public List<string>? AppliedTags { get; set; }
    
    /// <summary>
    /// Not supported at the moment. Please check our roadmap
    /// </summary>
    [JsonPropertyName("poll")] public PollCreateRequest? Poll { get; set; }
    
    private MultipartFormDataContent? _cachedMultipartContent;
    private bool _isMultipartContentDirty = true;
    
    /// <summary>
    /// Gets the MultipartFormDataContent for this webhook payload
    /// MultiPartContent is required when you're sending attachments or files
    /// This property lazily creates and caches the content, rebuilding it only when necessary
    /// Refer to Discord's documentation for more details: https://discord.com/developers/docs/reference#uploading-files
    /// </summary>
    [JsonIgnore]
    public MultipartFormDataContent? MultipartContent
    {
        get
        {
            if (_cachedMultipartContent is null || _isMultipartContentDirty)
            {
                _cachedMultipartContent = BuildMultipartContent();
                _isMultipartContentDirty = false;
            }
            
            return _cachedMultipartContent;
        }
    }
    
    private MultipartFormDataContent BuildMultipartContent()
    {
        var content = new MultipartFormDataContent();
        
        var payloadJson = JsonSerializer.Serialize(this, HookiJsonSerializerOptions.Default);
        
        PayloadJson = payloadJson;

        // Add files
        if (Files != null)
        {
            foreach (var file in Files)
            {
                var fileContent = new ByteArrayContent(file.FileContents);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                
                content.Add(fileContent, $"files[{file.SnowflakeId}]", file.FileName);
            }
        }
        
        // Add attachments
        if (Attachments != null)
        {
            foreach (var attachment in Attachments)
            {
                if (attachment.Content != null)
                {
                    var fileContent = new ByteArrayContent(attachment.Content);
                    if (!string.IsNullOrEmpty(attachment.ContentType))
                    {
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(attachment.ContentType);
                    }
                    content.Add(fileContent, $"files[{attachment.Id}]", attachment.FileName);
                }
            }
        }

        return content;
    }
}