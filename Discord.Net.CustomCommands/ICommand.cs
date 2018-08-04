using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ICommand<in TContext>
    {
        Task InvokeAsync(TContext context, CancellationToken cancellationToken);
    }
}