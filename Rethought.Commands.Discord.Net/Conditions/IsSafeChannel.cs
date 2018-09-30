using System;
using System.Collections.Generic;
using System.Text;

namespace Rethought.Commands.Discord.Net.Conditions
{
    public class IsSafeChannel : ICondition<DiscordContext>
    {
        public bool Satisfied(DiscordContext context)
            => context.Channel is SocketTextChannel socketTextChannel && !socketTextChannel.IsNsfw;
    }
}
