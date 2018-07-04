using System;

namespace Discord.Net.CustomCommands.Prefix
{
    public class StringPrefix : IPrefix
    {
        public StringPrefix(string value)
        {
            Value = value;
        }

        public bool HasPrefix(string input)
        {
            return input.Equals(Value);
        }

        public string Remove(string input)
        {
            var index = input.IndexOf(Value, StringComparison.Ordinal);
            return index < 0
                ? throw new InvalidOperationException("Input doesn't contain prefix")
                : input.Remove(index, Value.Length);
        }

        public string Value { get; }
    }
}                          