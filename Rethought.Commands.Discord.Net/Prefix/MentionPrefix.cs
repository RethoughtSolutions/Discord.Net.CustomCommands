using System.Linq;
using Discord;
using Optional;
using Rethought.Commands.Prefix;
using Rethought.Extensions.Optional;

namespace Rethought.Commands.Discord.Net.Prefix
{
    public class MentionPrefix : IPrefix
    {
        private readonly IUser user;

        public MentionPrefix(IUser user)
        {
            this.user = user;
        }

        public Option<string> Normalize(string input)
        {
            var firstWord = input.Split(' ').First();

            if (MentionUtils.TryParseUser(firstWord, out var id) && id == user.Id)
            {
                return Option.Some(input.Remove(0, firstWord.Length));
            }

            return default;
        }
    }

    
}

