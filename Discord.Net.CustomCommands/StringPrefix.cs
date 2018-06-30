namespace Discord.Net.CustomCommands
{
    public class StringPrefix : IPrefix
    {
        public StringPrefix(string value)
        {
            Value = value;
        }

        public bool Valid(string input)
        {
            return input.Equals(Value);
        }

        public string Value { get; }
    }
}