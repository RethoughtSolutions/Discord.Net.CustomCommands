using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public abstract class CommandBase<TContext>
    {
        protected readonly Type Type;

        protected Func<TContext, Task> CurriedFunc;

        private readonly IList<string> internalList = new List<string>();

        public IReadOnlyList<string> Aliases => internalList.ToImmutableList();

        public string Description { get; set; }

        public string Intent { get; }

        protected CommandBase(Type type, string intent)
        {
            Type = type;
            Intent = intent;
        }

        public void AddAlias(string alias)
        {
            internalList.Add(alias);
        }

        public void AddAliases(IEnumerable<string> aliases)
        {
            foreach (var alias in aliases)
                AddAlias(alias);
        }

        public async Task Execute(TContext context)
        {
            await CurriedFunc.Invoke(context);
        }
    }
}