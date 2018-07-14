using Optional;

namespace Discord.Net.CustomCommands.Prefix
{
    public interface IPrefixRemovalService
    {
        Option<string> Process(string message, ulong guildId);
    }
}