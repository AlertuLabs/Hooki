<div align="center">

  <img src="./assets/hooki-icon.png" alt="logo" width="100" height="auto" />
  <h1>Hooki</h1>
  
  <p>
    An awesome library created by <a href="https://alertu.io">Alertu</a> to help with implementing incoming webhooks for various applications! 
  </p>
  
<!-- Badges -->
<p>
    <a href="https://www.nuget.org/packages/Hooki/">
      <img src="https://img.shields.io/nuget/dt/Hooki.svg" alt="nuget downloads" />
    </a>
    <a href="https://www.nuget.org/packages/Hooki/">
      <img src="https://img.shields.io/nuget/v/Hooki.svg" alt="latest version" />
    </a>
    <a href="https://github.com/AlertuLabs/Hooki/graphs/contributors">
      <img src="https://img.shields.io/github/contributors/AlertuLabs/Hooki" alt="contributors" />
    </a>
    <a href="">
      <img src="https://img.shields.io/github/last-commit/AlertuLabs/Hooki" alt="last update" />
    </a>
    <a href="https://github.com/AlertuLabs/Hooki/network/members">
      <img src="https://img.shields.io/github/forks/AlertuLabs/Hooki" alt="forks" />
    </a>
    <a href="https://github.com/AlertuLabs/Hooki/stargazers">
      <img src="https://img.shields.io/github/stars/AlertuLabs/Hooki" alt="stars" />
    </a>
    <a href="https://github.com/AlertuLabs/Hooki/issues/">
      <img src="https://img.shields.io/github/issues/AlertuLabs/Hooki" alt="open issues" />
    </a>
    <a href="https://github.com/AlertuLabs/Hooki/blob/master/LICENSE">
      <img src="https://img.shields.io/github/license/AlertuLabs/Hooki.svg" alt="license" />
    </a>
</p>
   
<h4>
    <a href="https://github.com/AlertuLabs/Hooki/tree/main/docs/examples">View Examples</a>
  <span> · </span>
    <a href="https://github.com/AlertuLabs/Hooki/tree/main/docs">Documentation</a>
  <span> · </span>
    <a href="https://github.com/AlertuLabs/Hooki/issues/">Report Bug</a>
  <span> · </span>
    <a href="https://github.com/AlertuLabs/Hooki/issues/">Request Feature</a>
  </h4>
</div>

<br />

<!-- Table of Contents -->
# 📔 Table of Contents

- [About Hooki](#star2-about-the-project)
  * [Features](#dart-features)
  * [Why use Hooki?](#key-why-use-hooki)
- [Trusted By](#office-trusted-by)
- [Getting Started](#toolbox-getting-started)
  * [Prerequisites](#bangbang-prerequisites)
- [Usage](#eyes-usage)
- [Roadmap](#compass-roadmap)
- [Contributing](#wave-contributing)
  * [Code of Conduct](#scroll-code-of-conduct)
- [License](#warning-license)
- [Contact](#handshake-contact)
- [Acknowledgements](#gem-acknowledgements)
  

<!-- About the Project -->
## 🌟 About the Project

<div align="center">
    <img width="48" height="48" src="https://img.icons8.com/color/48/discord--v2.png" alt="discord--v2"/>
    <img width="48" height="48" src="https://img.icons8.com/fluency/48/microsoft-teams-2019.png" alt="microsoft-teams-2019"/>
    <img width="48" height="48" src="https://img.icons8.com/color-glass/48/slack-new.png"  alt="slack-new"/>
</div>

<!-- Features -->
### 🎯 Features

- Strongly typed POCOs for the following platforms:
  - Discord Webhook API
  - Slack Block Kit SDK
  - Microsoft Teams Message Card
- Compile-time checks for missing properties
- Type safety ensuring correct payload structure
- Leveraging existing platform SDKs and standards

<!-- Why use Hooki? -->
### 🪝 Why use Hooki?

Hooki is a powerful .NET library designed to simplify the creation of webhook payloads for popular platforms like Discord, Slack, and Microsoft Teams. It provides a set of strongly-typed C# POCO classes that serve as building blocks, allowing developers to easily construct and serialize webhook payloads into JSON format.

**Main Benefits:**
- **Simplified Development:** Pre-built POCOs for common webhook JSON payloads across various platforms.
- **Type Safety:** Strongly-typed classes ensure compile-time checks and prevent runtime errors.
- **Clean Code:** Eliminates the need for anonymous objects and inline JSON strings.
- **Focus on Content:** Concentrate on your payload's data and style rather than low-level JSON structure.
- **Flexibility:** Easily extensible for custom webhook requirements while maintaining type safety.

## 🏢 Trusted By

<div align="center">
  <table>
    <tr>
      <td align="center">
        <a href="https://cloudcat.dev">
          <img src="https://cloudcat.dev/img/logo.svg" width="100px;" alt="Cloudcat Logo"/>
        </a>
      </td>
    </tr>
    <tr>
      <td align="center">Cloudcat.dev</td>
    </tr>
  </table>
</div>

<!-- Getting Started -->
##  🧰 Getting Started

<!-- Prerequisites -->
### ‼️ Prerequisites

The only requirement is compatibility with .net 8.0.x

<!-- Usage -->
## 👀 Usage

```csharp
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Hooki.Discord.Enums;
using Hooki.Discord.Models.BuildingBlocks;
using Hooki.Discord.Models;

public class DiscordWebhookService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<DiscordWebhookService> _logger;

    public DiscordWebhookService(IHttpClientFactory httpClientFactory, ILogger<DiscordWebhookService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    private DiscordWebhookPayload CreateDiscordPayload()
    {
        return new DiscordWebhookPayload
        {
            Username = "Alertu Webhook",
            AvatarUrl = "https://example-url/image.png",
            Embeds = new List<Embed>
            {
                new Embed
                {
                    Author = new EmbedAuthor
                    {
                        Name = "Alertu",
                        Url = "https://alertu.io",
                        IconUrl = "https://example-url/image.png"
                    },
                    Title = $"Azure Metric Alert triggered",
                    Description = $"[**View in Alertu**](https://alertu.io) | [**View in Azure**](https://portal.azure.com)",
                    Color = 959721,
                    Fields = new List<EmbedField>
                    {
                        new EmbedField { Name = "Summary", Value = "This is a test summary", Inline = false },
                        new EmbedField { Name = "Organization Name", Value = "Test Organization", Inline = true },
                        new EmbedField { Name = "Project Name", Value = "Test Project", Inline = true },
                        new EmbedField { Name = "Cloud Provider", Value = "Azure", Inline = true },
                        new EmbedField { Name = "Resources", Value = "test-redis, test-postgreSQL", Inline = true },
                        new EmbedField { Name = "Severity", Value = "Critical", Inline = true },
                        new EmbedField { Name = "Status", Value = "Open", Inline = true },
                        new EmbedField { Name = "Triggered At", Value = DateTimeOffset.UtcNow.ToString("f"), Inline = true },
                        new EmbedField { Name = "Resolved At", Value = DateTimeOffset.UtcNow.ToString("f"), Inline = true }
                    }
                }
            }
        };
    }

    public async Task SendWebhookAsync(string webhookUrl, CancellationToken cancellationToken)
    {
        try
        {
            var discordPayload = CreateDiscordPayload();
            var jsonString = JsonSerializer.Serialize(discordPayload);

            using var client = _httpClientFactory.CreateClient();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(webhookUrl, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            _logger.LogInformation($"Successfully posted a Discord message to the webhook URL: {webhookUrl}");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, $"Failed to post Discord message to webhook URL: {webhookUrl}");
            throw;
        }
    }
}

// Example usage
public class ExampleController
{
    private readonly DiscordWebhookService _discordWebhookService;

    public ExampleController(DiscordWebhookService discordWebhookService)
    {
        _discordWebhookService = discordWebhookService;
    }

    public async Task SendDiscordNotification()
    {
        string webhookUrl = "https://discord.com/api/webhooks/your-webhook-url-here";
        await _discordWebhookService.SendWebhookAsync(webhookUrl, CancellationToken.None);
    }
}
```

<!-- Roadmap -->
## 🧭 Roadmap

* [x] POCOs
* [x] Implement Unit Tests
* [x] Provide builders utilising fluent api to reduce boilerplate code when creating webhook payloads
* [ ] Support Files and Polls in Discord Webhook
* [ ] Implement type safety POCOs for Discord message components
* [ ] Introduce Validation to provide a better developer experience (Apps are not returning error details for 400s)
* [ ] Remove the use of objects in numerous places and replace with a clean union type solution for type safety and readability
* [ ] Support other languages?

<!-- Contributing -->
## 👋 Contributing

<a href="https://github.com/AlertuLabs/Hooki/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=AlertuLabs/Hooki" />
</a>

Contributions are always welcome!

Please read [Contributing](https://github.com/AlertuLabs/Hooki/blob/main/.github/CONTRIBUTING.md) for ways to get started.

<!-- Code of Conduct -->
### 📜 Code of Conduct

Please read the [Code of Conduct](https://github.com/AlertuLabs/Hooki/blob/main/.github/CODE_OF_CONDUCT.md)

<!-- License -->
## ⚠️ License

Distributed under MIT License. See LICENSE.txt for more information.

<!-- Contact -->
## 🤝 Contact

Adam Ferguson - [@adamthewilliam](https://twitter.com/adamthewilliam)

<!-- Acknowledgments -->
## 💎 Acknowledgements

 - [Readme Template](https://github.com/Louis3797/awesome-readme-template)
