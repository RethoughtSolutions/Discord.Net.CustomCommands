namespace Discord.Net.CustomCommands
{
    /// <summary>
    ///     Translates the raw message into a list of raw parameters
    /// </summary>
    public interface IInputResolver
    {
        ResolvedInput Resolve(string input);
    }
}