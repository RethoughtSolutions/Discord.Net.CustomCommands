using System;
using System.Text;
using Optional;
using Optional.Collections;

namespace Discord.Net.CustomCommands.Prefix
{
    public class PrefixRemovalService : IPrefixRemovalService
    {
        private readonly IPrefixRepository prefixRepository;

        public PrefixRemovalService(IPrefixRepository prefixRepository)
        {
            this.prefixRepository = prefixRepository;
        }

        // TODO Make Option TryGetValue Extension Package
        public Option<string> Process(string message, ulong guildId)
        {
            return prefixRepository.Get(guildId)
                .Match(
                    prefixes => prefixes.FirstOrNone(prefix => prefix.HasPrefix(message))
                        .Match(prefix => prefix.Remove(message).Some(), Option.None<string>), Option.None<string>);
        }
    }
}
