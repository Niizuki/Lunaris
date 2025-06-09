using System.Threading;
using System.Threading.Tasks;

namespace Lunaris
{
    public interface ICommandHandler<TCommand>
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
