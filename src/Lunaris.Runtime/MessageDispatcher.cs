using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Lunaris
{
    public class MessageDispatcher
    {
        private readonly IServiceProvider _provider;

        public MessageDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken token = default)
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command, token);
        }
    }
}
