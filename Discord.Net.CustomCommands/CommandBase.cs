﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    public abstract class CommandBase<TContext>
    {
        protected readonly Type Type;

        protected Func<TContext, CancellationToken, Task> CurriedFunc;

        public string Description { get; set; }

        public string Intent { get; }

        protected CommandBase(Type type, string intent)
        {
            Type = type;
            Intent = intent;
        }

        public async Task ExecuteAsync(TContext context, CancellationToken cancellationToken)
        {
            await CurriedFunc.Invoke(context, cancellationToken);
        }
    }
}