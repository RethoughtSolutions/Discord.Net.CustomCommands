using System;

namespace Discord.Net.CustomCommands.Prefix
{
    public class MentionPrefix : IPrefix
    {
        private readonly IUser user;

        public MentionPrefix(IUser user)
        {
            this.user = user;
        }

        public bool HasPrefix(string input)
        {
            return MentionUtils.TryParseUser(input, out var id) && id == user.Id;
        }

        public string Remove(string input)
        {
            var index = input.IndexOf(Value, StringComparison.Ordinal);
            return index < 0
                ? input
                : input.Remove(index, Value.Length);

        }

        public string Value => user.Mention;
    }
}