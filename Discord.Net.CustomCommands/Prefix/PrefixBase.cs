﻿using System;

namespace Discord.Net.CustomCommands.Prefix
{
    public abstract class PrefixBase : IPrefix
    {
        public abstract string Value { get; }
        public abstract bool HasPrefix(string input);

        public virtual string Remove(string input)
        {
            var index = input.IndexOf(Value, StringComparison.Ordinal);
            return index < 0
                ? throw new InvalidOperationException("Input doesn't contain prefix")
                : input.Remove(index, Value.Length);
        }
    }
}