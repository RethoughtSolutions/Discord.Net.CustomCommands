using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ICommandService<TContext>
    {
        void AddCommand(CommandBase<TContext> commandBase);
        void AddCommands(IEnumerable<CommandBase<TContext>> commandBases);
        Task ExecuteCommandAsync(IUserMessage userMessage, CancellationToken cancellationToken);
    }
}