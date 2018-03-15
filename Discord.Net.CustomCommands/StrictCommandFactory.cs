namespace Discord.Net.CustomCommands
{
    public class StrictCommandFactory
    {
        private readonly ContextParser<DiscordContext> contextParser;
        private readonly IInputResolver inputResolver;

        public StrictCommandFactory(IInputResolver inputResolver, ContextParser<DiscordContext> contextParser)
        {
            this.inputResolver = inputResolver;
            this.contextParser = contextParser;
        }

        public StrictCommand<T> Create<T>(string name) where T : class, new()
        {
            return new StrictCommand<T>(inputResolver, contextParser, name);
        }

        public StrictCommand<T> Create<T>(ContextParser<DiscordContext> customContextParser, string name)
            where T : class, new()
        {
            return new StrictCommand<T>(inputResolver, customContextParser, name);
        }
    }
}