namespace Discord.Net.CustomCommands
{
    public class MentionPrefix : IPrefix
    {
        private readonly IUser user;

        public MentionPrefix(IUser user)
        {
            this.user = user;
        }
        public bool Valid(string input)
        {
            return MentionUtils.TryParseUser(input, out var id) && id == user.Id;
        }

        public string Value => user.Mention;
    }
}