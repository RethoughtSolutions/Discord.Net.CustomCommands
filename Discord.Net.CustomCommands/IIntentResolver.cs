namespace Discord.Net.CustomCommands
{
    public interface IIntentResolver
    {
        string Resolve(string message);
    }
}