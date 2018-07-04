using System.Linq;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    // TODO Apply Option-Pattern
    public class UserTypeParser
    {
        public async Task<IGuildUser> DirectParseAsync(IGuild guild, string input)
        {
            var result = await ParseByMention(guild, input).ConfigureAwait(false);

            if (result != null) return result;

            if (ulong.TryParse(input, out var id))
            {
                result = await ParseById(guild, id).ConfigureAwait(false);

                if (result != null) return result;

                return await ParseByUsername(guild, input).ConfigureAwait(false);
            }

            return await ParseByUsername(guild, input).ConfigureAwait(false);
        }

        private static async Task<IGuildUser> ParseByMention(IGuild guild, string input)
        {
            if (MentionUtils.TryParseUser(input, out var id))
            {
                return await guild.GetUserAsync(id).ConfigureAwait(false);
            }

            return null;
        }

        private static async Task<IGuildUser> ParseById(IGuild guild, ulong input)
        {
            return await guild.GetUserAsync(input);
        }

        private static async Task<IGuildUser> ParseByUsername(IGuild guild, string input)
        {
            var users = await guild.GetUsersAsync();

            return users.FirstOrDefault(x => x.Username == input);
        }
    }
}