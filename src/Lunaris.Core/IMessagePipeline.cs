using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lunaris;
public interface IMessagePipeline
{
    Task InvokeAsync(object message, Func<Task> next, CancellationToken cancellationToken = default);
}
