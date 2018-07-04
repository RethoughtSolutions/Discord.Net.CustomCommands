using System;
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

        public override bool HasPrefix(string input)
        {
            var firstWord = input.Split(' ').First();

            return MentionUtils.TryParseUser(firstWord, out var id) && id == user.Id;
        }

        public override string Value => user.Mention;
    }

    public abstract class RemovePrefixBase : IPrefix
    {
        public abstract bool HasPrefix(string input);

        public virtual string Remove(string input)
        {
            var index = input.IndexOf(Value, StringComparison.Ordinal);
            return index < 0
                ? throw new InvalidOperationException("Input doesn't contain prefix")
                : input.Remove(index, Value.Length);
        }

        public abstract string Value { get; }
    }
}