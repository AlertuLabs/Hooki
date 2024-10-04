using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Config;

public class HttpClientFixture : IDisposable
{
    public HttpClient Client { get; }
    public IConfiguration Configuration { get; }

    public HttpClientFixture()
    {
        Client = new HttpClient();

        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

        if (environment is "Development")
        {
            DotNetEnv.Env.TraversePath().Load();
        }
        
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    public void Dispose()
    {
        Client.Dispose();
    }
}