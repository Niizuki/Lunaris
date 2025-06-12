using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Lunaris;
public class MessageDispatcherWithPipeline
{
    private readonly IServiceProvider _provider;
    private readonly IEnumerable<IMessagePipeline> _pipelines;

    public MessageDispatcherWithPipeline(IServiceProvider provider)
    {
        _provider = provider;
        _pipelines = provider.GetServices<IMessagePipeline>();
    }

    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken token = default)
    {
        var handler = _provider.GetRequiredService<ICommandHandler<TCommand>>();
        var enumerator = _pipelines.GetEnumerator();
        Task Handler() => handler.HandleAsync(command, token);

        async Task Next()
        {
            if (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                await current.InvokeAsync(command!, Next, token);
            }
            else
            {
                await Handler();
            }
        }

        await Next();
    }
}
