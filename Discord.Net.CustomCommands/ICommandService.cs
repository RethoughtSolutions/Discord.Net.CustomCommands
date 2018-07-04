using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ICommandService<TContext>
    {
        Task ExecuteCommandAsync(IUserMessage userMessage, CancellationToken cancellationToken);
    }
}