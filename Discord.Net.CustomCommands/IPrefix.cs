namespace Discord.Net.CustomCommands
{
    public interface IPrefix
    {
        bool Valid(string input);

        string Value { get; }
    }
}