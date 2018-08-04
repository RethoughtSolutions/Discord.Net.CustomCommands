using System;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public abstract class CommandBase<TContext> : ICommand<TContext>
    {
        protected readonly Func<TContext, CancellationToken, Task> Func;

        protected CommandBase(Func<TContext, CancellationToken, Task> func)
        {
            Func = func;
        }

        public async Task InvokeAsync(TContext context, CancellationToken cancellationToken)
        {
            await Func.Invoke(context, cancellationToken).ConfigureAwait(false);
        }
    }
}