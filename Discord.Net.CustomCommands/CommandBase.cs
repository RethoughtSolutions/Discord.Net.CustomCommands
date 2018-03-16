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

        public string Description { get; set; }

        public string Intent { get; }

        protected CommandBase(Type type, string intent)
        {
            Type = type;
            Intent = intent;
        }

        public async Task Execute(TContext context)
        {
            await CurriedFunc.Invoke(context);
        }
    }
}