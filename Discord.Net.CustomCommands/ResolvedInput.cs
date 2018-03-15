using System.Collections.Generic;

namespace Discord.Net.CustomCommands
{
    /// <summary>
    ///     Takes an input and tries to find substrings representing parameters
    /// </summary>
    public class ResolvedInput
    {
        public string Intent { get; }

        public string Prefix { get; }

        public IReadOnlyList<string> Parameters { get; }

        public ResolvedInput(string prefix, string intent, IReadOnlyList<string> parameters)
        {
            Intent = intent;
            Parameters = parameters;
            Prefix = prefix;
        }
    }
}