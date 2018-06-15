using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public class StrictCommand<T> : CommandBase<DiscordContext> where T : class, new()
    {
        private readonly ContextParser<DiscordContext> contextParser;
        private readonly IInputResolver inputResolver;

        private readonly IList<Func<T, DiscordContext, Task<bool>>> preConditions =
            new List<Func<T, DiscordContext, Task<bool>>>();

        public StrictCommand(IInputResolver inputResolver, ContextParser<DiscordContext> contextParser, string intent)
            : base(typeof(T), intent)
        {
            this.contextParser = contextParser;
            this.inputResolver = inputResolver;
        }

        public void AddPrecondition(Func<T, DiscordContext, Task<bool>> precondition)
        {
            preConditions.Add(precondition);
        }

        public void AddPrecondition(Func<DiscordContext, Task<bool>> precondition)
        {
            preConditions.Add((specificContext, context) => precondition.Invoke(context));
        }

        public void AddPrecondition(Func<T, Task<bool>> precondition)
        {
            preConditions.Add((specificContext, context) => precondition.Invoke(specificContext));
        }

        public void SetFunc(Func<T, DiscordContext, Task> func)
        {
            // TODO use cancellationToken
            async Task Func(DiscordContext context, CancellationToken cancellationToken)
            {
                var inputs = inputResolver.Resolve(context.Message.Content);

                var specificContext = await contextParser.Parse<T>(context, inputs.Parameters);

                foreach (var preCondition in preConditions)
                {
                    var result = await preCondition.Invoke(specificContext, context);

                    if (!result) return;
                }

                await func.Invoke(specificContext, context);
            }

            CurriedFunc = Func;
        }
    }
}