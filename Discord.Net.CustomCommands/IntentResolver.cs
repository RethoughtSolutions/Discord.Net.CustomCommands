using System.Linq;

namespace Discord.Net.CustomCommands
{
    public class IntentResolver : IIntentResolver
    {
        public string Resolve(string message)
        {
            return message.Split(new []{' '}, 2).First();
        }
    }
}