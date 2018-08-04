using System.Linq;
using System.Threading.Tasks;
using Optional;

namespace Discord.Net.CustomCommands.Parser
{
    public class UserAsyncTypeParser : IAsyncTypeParser<IGuildUser, UserTypeParserInput>
    {
        public async Task<Option<IGuildUser>> ParseAsync(UserTypeParserInput input)
        {
            var result = await ParseByMentionAsync(input.Guild, input.Username).ConfigureAwait(false);

            if (result != null) return Option.None<IGuildUser>();

            if (ulong.TryParse(input.Username, out var id))
            {
                result = await ParseByIdAsync(input.Guild, id).ConfigureAwait(false);

                if (result != null) return result.Some();

                return (await ParseByUsernameAsync(input.Guild, input.Username).ConfigureAwait(false)).Some();
            }

            return (await ParseByUsernameAsync(input.Guild, input.Username).ConfigureAwait(false)).Some();
        }

        // TODO Apply Option Pattern
        private static async Task<IGuildUser> ParseByMentionAsync(IGuild guild, string input)
        {
            if (MentionUtils.TryParseUser(input, out var id))
            {
                return await guild.GetUserAsync(id).ConfigureAwait(false);
            }

            return null;
        }

        // TODO Apply Option Pattern
        private static Task<IGuildUser> ParseByIdAsync(IGuild guild, ulong input)
        {
            return guild.GetUserAsync(input);
        }

        // TODO Apply Option Pattern
        private static async Task<IGuildUser> ParseByUsernameAsync(IGuild guild, string input)
        {
            var users = await guild.GetUsersAsync().ConfigureAwait(false);

            return users.FirstOrDefault(x => x.Username == input);
        }
    }
}