namespace Discord.Net.CustomCommands.Prefix
{
    public interface IPrefix
    {
        bool HasPrefix(string input);

        string Remove(string input);
    }

}