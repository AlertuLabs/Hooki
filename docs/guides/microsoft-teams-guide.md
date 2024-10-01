# Guide: Creating Microsoft Teams Message Card Payloads

This guide will walk you through using the provided POCOs (Plain Old CLR Objects) to create a message card payload for Microsoft Teams. The message card allows you to send rich, interactive messages to Teams channels or personal chats.

## Basic Structure

The main object you'll be working with is `MessageCard`. Here's a basic example of how to create one:

```csharp
var messageCard = new MessageCard
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

Sections allow you to group related information.

If your card represents a single "entity", you may be able to get away with not using any section. That said, sections support the concept of an "activity" which is often a good way to represent data in a card.

If your card represents multiple "entities" or is, for instance, a digest for a particular news source, you will definitely want to use multiple sections, one per "entity."

**Note: Don't include more than 10 sections**

```csharp
var section = new Section
{
    ActivityTitle = "**Section Title**",
    ActivitySubtitle = "Section Subtitle",
    ActivityText = "This is the section's text content",
    ActivityImage = "https://example.com/image.png"
};

messageCard.Sections = new List<Section> { section };
```

## Adding Facts

Facts are key-value pairs that can be added to a section:

```csharp
section.Facts = new List<Fact>
{
    new Fact { Name = "Project:", Value = "Project Phoenix" },
    new Fact { Name = "Status:", Value = "In Progress" }
};
```

## Adding Actions

Actions allow users to interact with your card. There are different types of actions available:

### OpenUri Action

```csharp
var openUriAction = new OpenUriAction
{
    Name = "View Details",
    Targets = new List<Target>
    {
        new Target { OperatingSystem = "default", Uri = "https://example.com/details" }
    }
};

messageCard.PotentialActions = new List<ActionBase> { openUriAction };
```

### HttpPost Action

```csharp
var httpPostAction = new HttpPostAction
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
var actionCard = new ActionCardAction
{
    Name = "Add Comment",
    Inputs = new List<InputBase>
    {
        new TextInput
        {
            Id = "comment",
            Title = "Enter your comment",
            IsMultiline = true
        }
    },
    Actions = new List<ActionBase>
    {
        new HttpPostAction
        {
            Name = "Submit",
            Target = "https://example.com/api/comment"
        }
    }
};

messageCard.PotentialActions.Add(actionCard);
```

## Complete Example

Here's a more comprehensive example that puts it all together:

```csharp
var messageCard = new MessageCard
{
    ThemeColor = "0x0EA5E9", // Light blue color
    Summary = "New Metric Alert: ALERT-001",
    Sections = new List<Section>
    {
        new Section
        {
            ActivityTitle = "**Azure Metric Alert triggered**",
            ActivitySubtitle = "**Severity - Critical | Status - Open**",
            ActivityText = "This is a test summary for the Azure Metric Alert",
            ActivityImage = "https://example-url/image.png",
            Facts = new List<Fact>
            {
                new Fact { Name = "Organization Name:", Value = "Test Organization" },
                new Fact { Name = "Project Name:", Value = "Test Project" },
                new Fact { Name = "Alert Group Name:", Value = "Test Alert Group" },
                new Fact { Name = "Cloud Provider:", Value = "Azure" },
                new Fact { Name = "Severity:", Value = "Critical" },
                new Fact { Name = "Status:", Value = "Open" },
                new Fact { Name = "Affected Resources:", Value = "test-redis, test-postgreSQL" },
                new Fact { Name = "Triggered At:", Value = DateTimeOffset.UtcNow.ToString("f") },
                new Fact { Name = "Resolved At:", Value = DateTimeOffset.UtcNow.ToString("f") }
            }
        }
    },
    PotentialActions = new List<ActionBase>
    {
        new OpenUriAction
        {
            Name = "View in Alertu",
            Targets = new List<Target>
            {
                new Target { OperatingSystem = "default", Uri = "https://alertu.io" }
            }
        },
        new OpenUriAction
        {
            Name = "View in Azure",
            Targets = new List<Target>
            {
                new Target { OperatingSystem = "default", Uri = "https://portal.azure.com" }
            }
        }
    }
};
```

## Markdown Styling

Microsoft Teams supports a subset of Markdown in message cards. Here's a table of common formatting options:

| Effect | Markdown | Example |
|--------|----------|---------|
| Italics | `*Italic*` | *Italic* |
| Bold | `**Bold**` | **Bold** |
| Bold italics | `***Bold Italic***` | ***Bold Italic*** |
| Strike-through | `~~Strike-through~~` | ~~Strike-through~~ |
| Links | `[Microsoft](https://www.microsoft.com)` | [Microsoft](https://www.microsoft.com) |
| Headings | `# Heading` through `###### Heading` | Varies from `<h1>` to `<h6>` |
| Bulleted lists | `* List item` or `- List item` | • List item |

You can use these Markdown elements in various text fields of your message card, such as `ActivityTitle`, `ActivitySubtitle`, `ActivityText`, and in the `Value` field of `Fact` objects.

Example usage in a message card:

```csharp
var section = new Section
{
    ActivityTitle = "**Important Update**",
    ActivitySubtitle = "*Please read carefully*",
    ActivityText = "We have made some changes:\n\n" +
                   "1. New feature added\n" +
                   "2. Bug fixes\n\n" +
                   "For more information, visit our [website](https://example.com).",
    Facts = new List<Fact>
    {
        new Fact { Name = "Status:", Value = "~~In Progress~~ **Completed**" },
        new Fact { Name = "Affected Systems:", Value = "• System A\n• System B" }
    }
};
```

Remember that while Markdown can enhance readability, it's important to use it judiciously to maintain a clean and professional appearance in your message cards.

## Notes

1. The `ThemeColor` property accepts a hexadecimal color value. Here is an example "0ea4e9".
2. The `Summary` field is used when the card is displayed in a notification or in a condensed view.
3. Images used in the card (like `ActivityImage`) should be accessible from the internet.
4. When using `OpenUriAction`, you can specify different URIs for different operating systems if needed.
5. The `HttpPostAction` can be used to send data back to your server when a user interacts with the card.
6. Remember to handle potential actions server-side if you're using interactive elements.

For more details on Microsoft Teams message card structure and capabilities, refer to the [official Microsoft documentation](https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference).