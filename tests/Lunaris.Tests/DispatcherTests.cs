using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Lunaris;

namespace Lunaris.Tests;

public class DispatcherTests
{
    public class PingCommand {}

    public class PingHandler : ICommandHandler<PingCommand>
    {
        public bool Handled { get; private set; }
        public Task HandleAsync(PingCommand command, CancellationToken cancellationToken = default)
        {
            Handled = true;
            return Task.CompletedTask;
        }
    }

    [Test]
    public async Task DispatchAsync_InvokesHandler()
    {
        var services = new ServiceCollection();
        var handler = new PingHandler();
        services.AddSingleton<ICommandHandler<PingCommand>>(handler);
        var provider = services.BuildServiceProvider();
        var dispatcher = new MessageDispatcher(provider);

        await dispatcher.DispatchAsync(new PingCommand());

        Assert.IsTrue(handler.Handled);
    }
}
