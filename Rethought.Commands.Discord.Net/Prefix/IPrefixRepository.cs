using System.Collections.Generic;
using Optional;
using Rethought.Commands.Prefix;

namespace Rethought.Commands.Discord.Net.Prefix
{
    public interface IPrefixRepository
    {
        Option<IList<IPrefix>> Get(ulong guildId);
    }
}