using System.Linq;
using System.Threading.Tasks;
using Optional;

namespace Discord.Net.CustomCommands.Parser
{
    public struct UserTypeParserInput
    {
        public IGuild Guild { get; }
        public string Username { get; }

        public UserTypeParserInput(IGuild guild, string username)
        {
            Guild = guild;
            Username = username;
        }
    }

    public class UserAsyncTypeParser : IAsyncTypeParser<IGuildUser, UserTypeParserInput>
    {
        public async Task<Option<IGuildUser>> ParseAsync(UserTypeParserInput input)
        {
            var result = await ParseByMention(input.Guild, input.Username).ConfigureAwait(false);

            if (result != null) return Option.None<IGuildUser>();

            if (ulong.TryParse(input.Username, out var id))
            {
                result = await ParseById(input.Guild, id).ConfigureAwait(false);

                if (result != null) return result.Some();

                return (await ParseByUsername(input.Guild, input.Username).ConfigureAwait(false)).Some();
            }

            return (await ParseByUsername(input.Guild, input.Username).ConfigureAwait(false)).Some();
        }

        // TODO Apply Option Pattern
        private static async Task<IGuildUser> ParseByMention(IGuild guild, string input)
        {
            if (MentionUtils.TryParseUser(input, out var id))
            {
                return await guild.GetUserAsync(id).ConfigureAwait(false);
            }

            return null;
        }

        // TODO Apply Option Pattern
        private static async Task<IGuildUser> ParseById(IGuild guild, ulong input)
        {
            return await guild.GetUserAsync(input);
        }

        // TODO Apply Option Pattern
        private static async Task<IGuildUser> ParseByUsername(IGuild guild, string input)
        {
            var users = await guild.GetUsersAsync();

            return users.FirstOrDefault(x => x.Username == input);
        }
    }
}