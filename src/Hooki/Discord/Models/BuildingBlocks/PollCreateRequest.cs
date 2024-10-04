using System.Text.Json.Serialization;

namespace Hooki.Discord.Models.BuildingBlocks;

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/poll#poll-create-request-object
/// </summary>
public class PollCreateRequest
{
    [JsonPropertyName("question")] public required PollMedia Question { get; set; }
    
    [JsonPropertyName("answers")] public required List<PollAnswer> Answers { get; set; }
    
    [JsonPropertyName("duration")] public int? Duration { get; set; }
    
    [JsonPropertyName("allow_multiselect")] public bool? AllowMultiSelect { get; set; }
    
    [JsonPropertyName("layout_type")] public int? LayoutType { get; set; }
}

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/poll#poll-media-object
/// </summary>
public class PollMedia
{
    [JsonPropertyName("text")] public required string Text { get; set; }
    
    [JsonPropertyName("emoji")] public Emoji? Emoji { get; set; }
}

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/poll#poll-answer-object
/// </summary>
public class PollAnswer
{
    [JsonPropertyName("answer_id")] public int? AnswerId { get; set; }
    
    [JsonPropertyName("poll_media")] public required PollMedia PollMedia { get; set; }
}

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/emoji#emoji-object
/// </summary>
public class Emoji
{
    /// <summary>
    /// Provide Id when you're sending a custom emoji
    /// </summary>
    [JsonPropertyName("id")] public string? Id { get; set; }
    
    /// <summary>
    /// Provide Name when you're sending a default emoji and optionally when you're sending a custom emoji
    /// </summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    
    /// <summary>
    /// When provided, Roles should contain an array of Role object ids 
    /// </summary>
    [JsonPropertyName("roles")] public string[]? Roles { get; set; }
    
    //ToDo: Implement user object for type safety
    [JsonPropertyName("user")] public User? User { get; set; }
    
    [JsonPropertyName("require_colons")] public bool? RequireColons { get; set; }
    
    [JsonPropertyName("managed")] public bool? Managed { get; set; }
    
    [JsonPropertyName("animated")] public bool? Animated { get; set; }
    
    [JsonPropertyName("available")] public bool? Available { get; set; }
}

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/user#user-object
/// </summary>
public class User
{
    [JsonPropertyName("id")] public required string Id { get; set; }
    
    [JsonPropertyName("username")] public required string Username { get; set; }
    
    /// <summary>
    /// The User's Discord tag
    /// </summary>
    [JsonPropertyName("discriminator")] public required string Discriminator { get; set; }
    
    /// <summary>
    /// The User's display name, if it is set. For bots, this is the application name
    /// </summary>
    [JsonPropertyName("global_name")] public string? GlobalName { get; set; }
    
    /// <summary>
    /// The User's avatar hash
    /// </summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }
    
    /// <summary>
    /// Whether the user belongs to an OAuth2 application
    /// </summary>
    [JsonPropertyName("bot")] public bool? Bot { get; set; }
    
    /// <summary>
    /// Whether the User is an official Discord System user
    /// </summary>
    [JsonPropertyName("system")] public bool? System { get; set; }
    
    [JsonPropertyName("mfa_enabled")] public bool? MfaEnabled { get; set; }
    
    /// <summary>
    /// The User's banner hash
    /// </summary>
    [JsonPropertyName("banner")] public bool? Banner { get; set; }
    
    /// <summary>
    /// The User's banner color encoded as an integer representation of hexadecimal color code
    /// </summary>
    [JsonPropertyName("accent_color")] public int? AccentColor { get; set; }
    
    /// <summary>
    /// The User's chosen language option
    /// Refer to Discord's documentation to see the supported Locales: https://discord.com/developers/docs/reference#locales
    /// </summary>
    [JsonPropertyName("locale")] public string? Locale { get; set; }
    
    [JsonPropertyName("verified")] public bool? Verified { get; set; }
    
    /// <summary>
    /// The User's email
    /// </summary>
    [JsonPropertyName("email")] public string? Email { get; set; }
    
    /// <summary>
    /// Refer to Discord's documentation to see all the possible User flags: https://discord.com/developers/docs/resources/user#user-object-user-flags
    /// </summary>
    [JsonPropertyName("flags")] public int? Flags { get; set; }
    
    /// <summary>
    /// The type of Nitro subscription on a User's account
    /// Refer to Discord's documentation to see all possible premium types: https://discord.com/developers/docs/resources/user#user-object-premium-types
    /// </summary>
    [JsonPropertyName("premium_type")] public int? PremiumType { get; set; }
    
    /// <summary>
    /// Refer to Discord's documentation to see all the possible User flags: https://discord.com/developers/docs/resources/user#user-object-user-flags
    /// </summary>
    [JsonPropertyName("public_flags")] public int? PublicFlags { get; set; }
    
    [JsonPropertyName("avatar_decoration_data")] public AvatarDecorationData? AvatarDecorationData { get; set; }
}

/// <summary>
/// Please refer to Discord's documentation for more details: https://discord.com/developers/docs/resources/user#avatar-decoration-data-object
/// </summary>
public class AvatarDecorationData
{
    /// <summary>
    /// The Avatar decoration hash
    /// Refer to Discord's documentation for more details: https://discord.com/developers/docs/reference#image-formatting
    /// </summary>
    [JsonPropertyName("asset")] public required string Asset { get; set; }
    
    /// <summary>
    /// Id of the Avatar decoration's SKU
    /// </summary>
    [JsonPropertyName("sku_id")] public required string SkuId { get; set; }
}