using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public abstract class CommandBase<TContext> : ICommand<TContext>
    {
        protected Func<TContext, CancellationToken, Task> CurriedFunc;

        public async Task ExecuteAsync(TContext context, CancellationToken cancellationToken)
        {
            await CurriedFunc.Invoke(context, cancellationToken).ConfigureAwait(false);
        }
    }
}