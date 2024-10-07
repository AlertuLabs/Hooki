using System.Reflection;

namespace IntegrationTests.Extensions;

public static class ResourceReaderExtensions
{
    public static byte[] GetEmbeddedResourceBytes(string resourceName)
    {
        var hookiAssembly = Assembly.GetExecutingAssembly();
        var temp = hookiAssembly.GetManifestResourceNames();
        var fullResourceName = hookiAssembly.GetManifestResourceNames()
            .FirstOrDefault(name => name.EndsWith(resourceName));

        if (fullResourceName == null)
        {
            throw new FileNotFoundException($"Resource not found: {resourceName}");
        }

        using var stream = hookiAssembly.GetManifestResourceStream(fullResourceName);
        if (stream == null)
        {
            throw new InvalidOperationException($"Unable to load resource: {resourceName}");
        }

        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}