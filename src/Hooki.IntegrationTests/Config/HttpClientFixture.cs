using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Config;

public class HttpClientFixture : IDisposable
{
    public HttpClient Client { get; }
    public IConfiguration Configuration { get; }

    public HttpClientFixture()
    {
        Client = new HttpClient();
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .AddUserSecrets<HttpClientFixture>()
            .Build();
    }

    public void Dispose()
    {
        Client.Dispose();
    }
}