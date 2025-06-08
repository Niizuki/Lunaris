using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Lunaris.Tests;

public class AddLunarisTests
{
    [Service]
    private class SampleService {}

    [Test]
    public void AddLunaris_RegistersServiceWithAttribute()
    {
        var services = new ServiceCollection();
        services.AddLunaris(typeof(SampleService).Assembly);
        var provider = services.BuildServiceProvider();
        var service = provider.GetService<SampleService>();
        Assert.IsNotNull(service);
    }
}
