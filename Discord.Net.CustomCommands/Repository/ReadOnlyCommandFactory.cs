using System.Collections.Generic;
using Optional;
using Optional.Collections;

namespace Discord.Net.CustomCommands.Repository
{
    public class ReadOnlyCommandFactory<TContext> : ICommandRepository<TContext>
    {
        private readonly IReadOnlyList<CommandBase<TContext>> commandBases;

        public ReadOnlyCommandFactory(IReadOnlyList<CommandBase<TContext>> commandBases)
        {
            this.commandBases = commandBases;
        }

        public Option<CommandBase<TContext>> Get(string intent)
        {
            return this.commandBases.FirstOrNone(x => x.Intent == intent);
        }
    }
}