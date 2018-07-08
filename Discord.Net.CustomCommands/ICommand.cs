using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ICommand<in TContext>
    {
        Task ExecuteAsync(TContext context, CancellationToken cancellationToken);
    }
}