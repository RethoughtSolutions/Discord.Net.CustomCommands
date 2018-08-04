using System.Linq;

namespace Discord.Net.CustomCommands.Prefix
{
    public class StringPrefix : RemovePrefixBase
    {
        public StringPrefix(string value)
        {
            Value = value;
        }

        public override string Value { get; }

        public override bool HasPrefix(string input)
        {
            var firstWord = input.Split(' ').First();

            return input.Equals(firstWord);
        }
    }
}