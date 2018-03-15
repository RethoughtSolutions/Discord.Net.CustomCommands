using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public interface ITypeParser<in TContext>
    {
        Task<object> ParseAsync(TContext context, string input);
    }
}