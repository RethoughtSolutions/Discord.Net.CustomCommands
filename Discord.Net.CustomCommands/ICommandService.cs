using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ICommandService<TContext>
    {
        Task<CommandBase<TContext>> ExecuteCommandAsync(string userMessage, CancellationToken cancellationToken);
    }
}