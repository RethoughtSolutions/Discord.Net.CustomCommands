namespace Discord.Net.CustomCommands
{
    public class ContextFactory
    {
        private readonly IDiscordClient discordClient;

        public ContextFactory(IDiscordClient discordClient)
        {
            this.discordClient = discordClient;
        }

        public DiscordContext Create(IUserMessage userMessage)
        {
            return new DiscordContext(discordClient, userMessage);
        }
    }
}