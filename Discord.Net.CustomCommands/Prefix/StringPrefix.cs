using System.Linq;

namespace Discord.Net.CustomCommands.Prefix
{
    public class StringPrefix : PrefixBase
    {
        public StringPrefix(string value)
        {
            Value = value;
        }

        public override string Value { get; }

        public override bool HasPrefix(string input)
        {
            // TODO change this algorithm to search for a substring in the string and only accept it if the whole message beginns with that substring
            var firstWord = input.Split(' ').First();

            return input.Equals(firstWord);
        }
    }
}