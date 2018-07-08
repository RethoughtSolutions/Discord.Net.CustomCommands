using System.Threading.Tasks;
using Optional;

namespace Discord.Net.CustomCommands.Parser
{
    public interface IAsyncTypeParser<TOutput, in TInput>
    {
        Task<Option<TOutput>> ParseAsync(TInput input);
    }
}