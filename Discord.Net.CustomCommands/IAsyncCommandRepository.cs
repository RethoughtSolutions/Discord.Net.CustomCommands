using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface IAsyncCommandRepository<TContext>
    {
        Task<CommandBase<TContext>> Get(string userMessage, CancellationToken cancellationToken);
    }
}