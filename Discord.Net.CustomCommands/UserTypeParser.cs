using System.Linq;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public class UserTypeParser
    {
        public async Task<IGuildUser> DirectParseAsync(IGuild guild, string input)
        {
            IGuildUser result = null;

            result = await ParseByMention(guild, input);

            if (result != null) return result;

            if (ulong.TryParse(input, out var id))
            {
                result = await ParseById(guild, id);
                if (result != null) return result;

            }


            result = await ParseByUsername(guild, input);

            return result;
        }

        private async Task<IGuildUser> ParseByMention(IGuild guild, string input)
        {
            if (MentionUtils.TryParseUser(input, out var id))
            {
                return await guild.GetUserAsync(id).ConfigureAwait(false);
            }

            return null;
        }

        private async Task<IGuildUser> ParseById(IGuild guild, ulong input)
        {
            return await guild.GetUserAsync(input);
        }

        private async Task<IGuildUser> ParseByUsername(IGuild guild, string input)
        {
            var users = await guild.GetUsersAsync();

            return users.FirstOrDefault(x => x.Username == input);
        }
    }
}