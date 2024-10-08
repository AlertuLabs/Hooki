# Guide: Creating Microsoft Teams Message Card Payloads with Hooki

This guide will walk you through using the Hooki library to create message card payloads for Microsoft Teams. Message cards allow you to send rich, interactive messages to Teams channels or personal chats.

## Table of Contents

1. [Basic Structure](#basic-structure)
2. [Adding Sections](#adding-sections)
3. [Adding Facts](#adding-facts)
4. [Adding Actions](#adding-actions)
   - [OpenUri Action](#openuri-action)
   - [HttpPost Action](#httppost-action)
   - [ActionCard Action](#actioncard-action)
5. [Complete Example](#complete-example)
6. [Markdown Styling in Teams Message Cards](#markdown-styling-in-teams-message-cards)
7. [Best Practices and Limitations](#best-practices-and-limitations)
8. [Additional Resources](#additional-resources)

## Basic Structure

The main object you'll be working with is `MessageCard`. Here's a basic example of how to create one:

```csharp
using Hooki.MicrosoftTeams.Models;

var messageCard = new MsTeamsWebhookPayload
{
    Type = "MessageCard",
    Context = "https://schema.org/extensions",
    ThemeColor = "0ea4e9",
    Summary = "Summary of the card",
    Title = "Card Title",
    Text = "This is the card's text content"
};
```

## Adding Sections

Sections allow you to group related information. Here's how to add a section:

```csharp
using Hooki.MicrosoftTeams.BuildingBlocks;

var section = new MsTeamsSection
{
    ActivityTitle = "**Section Title**",
    ActivitySubtitle = "Section Subtitle",
    ActivityText = "This is the section's text content",
    ActivityImage = "https://example.com/image.png"
};

messageCard.Sections = new List<MsTeamsSection> { section };
```

**Note:** Don't include more than 10 sections in a single card.

## Adding Facts

Facts are key-value pairs that can be added to a section:

```csharp
using Hooki.MicrosoftTeams.BuildingBlocks;

var facts = new List<MsTeamsFact>
{
    new MsTeamsFact { Name = "Project:", Value = "Project Phoenix" },
    new MsTeamsFact { Name = "Status:", Value = "In Progress" }
};

section.Facts = facts;
```

## Adding Actions

Actions allow users to interact with your card. There are different types of actions available:

### OpenUri Action

```csharp
using Hooki.MicrosoftTeams.Actions;
using Hooki.MicrosoftTeams.BuildingBlocks;

var openUriAction = new MsTeamsOpenUriAction
{
    Name = "View Details",
    Targets = new List<MsTeamsTarget>
    {
        new MsTeamsTarget { OperatingSystem = "default", Uri = "https://example.com/details" }
    }
};

messageCard.PotentialActions = new List<MsTeamsAction> { openUriAction };
```

### HttpPost Action

```csharp
using Hooki.MicrosoftTeams.Actions;

var httpPostAction = new MsTeamsHttpPostAction
{
    Name = "Approve",
    Target = "https://example.com/api/approve",
    Body = "{\"decision\": \"approved\"}"
};

messageCard.PotentialActions.Add(httpPostAction);
```

### ActionCard Action

ActionCard allows you to create a set of inputs that users can fill out:

```csharp
using Hooki.MicrosoftTeams.Actions;
using Hooki.MicrosoftTeams.Inputs;

var actionCard = new MsTeamsActionCardAction
{
    Name = "Add Comment",
    Inputs = new List<MsTeamsInput>
    {
        new MsTeamsTextInput
        {
            Id = "comment",
            Title = "Enter your comment",
            IsMultiline = true
        }
    },
    Actions = new List<MsTeamsAction>
    {
        new MsTeamsHttpPostAction
        {
            Name = "Submit",
            Target = "https://example.com/api/comment"
        }
    }
};

messageCard.PotentialActions.Add(actionCard);
```

## Complete Example

Here's a comprehensive example that puts it all together:

```csharp
using Hooki.MicrosoftTeams.Models;
using Hooki.MicrosoftTeams.BuildingBlocks;
using Hooki.MicrosoftTeams.Actions;

var payload = new MsTeamsWebhookPayload
{
    ThemeColor = "0x0EA5E9", // Light blue color
    Summary = "New Metric Alert: ALERT-001",
    Sections = new List<MsTeamsSection>
    {
        new MsTeamsSection
        {
            ActivityTitle = "**Azure Metric Alert triggered**",
            ActivitySubtitle = "**Severity - Critical | Status - Open**",
            ActivityText = "This is a test summary for the Azure Metric Alert",
            ActivityImage = "https://example.com/alert-image.png",
            Facts = new List<MsTeamsFact>
            {
                new MsTeamsFact { Name = "Organization Name:", Value = "Test Organization" },
                new MsTeamsFact { Name = "Project Name:", Value = "Test Project" },
                new MsTeamsFact { Name = "Alert Group Name:", Value = "Test Alert Group" },
                new MsTeamsFact { Name = "Cloud Provider:", Value = "Azure" },
                new MsTeamsFact { Name = "Severity:", Value = "Critical" },
                new MsTeamsFact { Name = "Status:", Value = "Open" },
                new MsTeamsFact { Name = "Affected Resources:", Value = "test-redis, test-postgreSQL" },
                new MsTeamsFact { Name = "Triggered At:", Value = DateTimeOffset.UtcNow.ToString("f") },
                new MsTeamsFact { Name = "Resolved At:", Value = DateTimeOffset.UtcNow.ToString("f") }
            }
        }
    },
    PotentialActions = new List<MsTeamsAction>
    {
        new MsTeamsOpenUriAction
        {
            Name = "View in Alertu",
            Targets = new List<MsTeamsTarget>
            {
                new MsTeamsTarget { OperatingSystem = "default", Uri = "https://alertu.io" }
            }
        },
        new MsTeamsOpenUriAction
        {
            Name = "View in Azure",
            Targets = new List<MsTeamsTarget>
            {
                new MsTeamsTarget { OperatingSystem = "default", Uri = "https://portal.azure.com" }
            }
        }
    }
};

// Serialize into JSON
var jsonString = payload.Serialize();
```

Please make sure to use the extension available on the `DiscordWebhookPayload`, `MsTeamsWebhookPayload` and `SlackWebhookPayload` classes to serialize the payload into JSON using Hooki's settings for convenience and consistency.

```csharp
// Build your payload with what you want to send
var payload = new MsTeamsWebhookPayload();

// Serialize your payload into JSON ready to send
var jsonString = payload.Serialize();
```

## Markdown Styling in Teams Message Cards

Microsoft Teams supports a subset of Markdown in message cards. Here are some common formatting options:

| Effect | Markdown | Example |
|--------|----------|---------|
| Italics | `*Italic*` | *Italic* |
| Bold | `**Bold**` | **Bold** |
| Bold italics | `***Bold Italic***` | ***Bold Italic*** |
| Strike-through | `~~Strike-through~~` | ~~Strike-through~~ |
| Links | `[Microsoft](https://www.microsoft.com)` | [Microsoft](https://www.microsoft.com) |
| Headings | `# Heading` through `###### Heading` | Varies from `<h1>` to `<h6>` |
| Bulleted lists | `* List item` or `- List item` | • List item |

Example usage in a message card:

```csharp
var section = new MsTeamsSection
{
    ActivityTitle = "**Important Update**",
    ActivitySubtitle = "*Please read carefully*",
    ActivityText = "We have made some changes:\n\n" +
                   "1. New feature added\n" +
                   "2. Bug fixes\n\n" +
                   "For more information, visit our [website](https://example.com).",
    Facts = new List<MsTeamsFact>
    {
        new MsTeamsFact { Name = "Status:", Value = "~~In Progress~~ **Completed**" },
        new MsTeamsFact { Name = "Affected Systems:", Value = "• System A\n• System B" }
    }
};
```

## Best Practices and Limitations

1. The `ThemeColor` property accepts a hexadecimal color value (e.g., "0ea4e9").
2. Use the `Summary` field for notifications or condensed views of the card.
3. Ensure images used in the card (like `ActivityImage`) are accessible from the internet.
4. With `MsTeamsOpenUriAction`, you can specify different URIs for different operating systems if needed.
5. Use `MsTeamsHttpPostAction` to send data back to your server when a user interacts with the card.
6. Remember to handle potential actions server-side if you're using interactive elements.
7. Limit the number of sections to 10 or fewer per card for better readability.
8. Use Markdown formatting judiciously to maintain a clean and professional appearance.

## Additional Resources

1. [Microsoft Teams Message Card Reference](https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference)
2. [Microsoft Teams Developer Platform](https://learn.microsoft.com/en-us/microsoftteams/platform/)