using System.Linq;

namespace Discord.Net.CustomCommands.Prefix
{
    public class MentionPrefix : RemovePrefixBase
    {
        private readonly IUser user;

        public MentionPrefix(IUser user)
        {
            this.user = user;
        }

        public override string Value => user.Mention;

        public override bool HasPrefix(string input)
        {
            var firstWord = input.Split(' ').First();

            return MentionUtils.TryParseUser(firstWord, out var id) && id == user.Id;
        }
    }
}