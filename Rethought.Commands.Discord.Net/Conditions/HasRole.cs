using System;
using System.Linq;
using Rethought.Commands.Conditions;

namespace Rethought.Commands.Discord.Net.Conditions
{
    public class IsUser : ICondition<DiscordContext>
    {
        public ulong[] UserIds { get; }

        public IsUser(params ulong[] userIds)
            => UserIds = userIds;

        public bool Satisfied(DiscordContext context)
        {
            if (UserIds.Any(x => x.Id == context.User.Id))
                return true;
            return false;
        }
    }
}
