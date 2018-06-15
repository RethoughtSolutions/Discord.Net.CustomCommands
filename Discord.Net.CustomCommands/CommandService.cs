//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Discord.Net.CustomCommands
//{
//    public class CommandService : ICommandService<DiscordContext>
//    {
//        private readonly ContextFactory contextFactory;

//        private readonly IIntentResolver intentResolver;

        


//        private readonly IList<CommandBase<DiscordContext>> strictCommands = new List<CommandBase<DiscordContext>>()
//            ;

        

//        public CommandService(ContextFactory contextFactory, WitAiContextFactory witAiContextFactory,
//            WitAiClient witAiClient, IIntentResolver intentResolver, IReadOnlyList<IPrefix> prefixes)
//        {
//            this.contextFactory = contextFactory;
//            this.witAiContextFactory = witAiContextFactory;

//            this.witAiClient = witAiClient;
//            this.intentResolver = intentResolver;
//            this.prefixes = prefixes;
//        }

//        public void AddCommand(CommandBase<DiscordContext> commandBase)
//        {
//            strictCommands.Add(commandBase);
//        }

//        public void AddCommands(IEnumerable<CommandBase<DiscordContext>> commandsBases)
//        {
//            foreach (var commandsBase in commandsBases)
//                AddCommand(commandsBase);
//        }

//        private readonly IReadOnlyList<IPrefix> prefixes;

//        public async Task ExecuteCommandAsync(IUserMessage userMessage)
//        {
//            //// TODO: Algorithm that decides which command to execute if both resolve algorithms return a result
//            //if (TryResolveStrictCommand(userMessage.Content, out var strictCommand))
//            //{
//            //    await strictCommand.ExecuteAsync(contextFactory.Create(userMessage));
//            //    return;
//            //}
//        }

        

        

//        public bool TryResolveStrictCommand(string input, out CommandBase<DiscordContext> strictCommand)
//        {
//            var intent = intentResolver.Resolve(input);
//            strictCommand = strictCommands.FirstOrDefault(x => x.Intent == intent);

//            return strictCommand != null;
//        }
//    }
//}