using System.Linq;
using Optional;

namespace Discord.Net.CustomCommands.Repository
{
    public interface ICommandRepository<TContext>
    {
        Option<CommandBase<TContext>> Get(string intent);
    }
}