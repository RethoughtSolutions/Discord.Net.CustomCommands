using System.Collections.Generic;
using Optional;

namespace Discord.Net.CustomCommands.Prefix
{
    public interface IPrefixRepository
    {
        Option<IList<IPrefix>> Get(ulong guildId);
    }
}