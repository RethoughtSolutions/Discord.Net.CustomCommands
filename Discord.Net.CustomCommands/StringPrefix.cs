namespace Discord.Net.CustomCommands
{
    public class StringPrefix : IPrefix
    {
        private readonly string value;

        public StringPrefix(string value)
        {
            this.value = value;
        }
        public bool Valid(string input)
        {
            return input.Equals(value);
        }
    }
}