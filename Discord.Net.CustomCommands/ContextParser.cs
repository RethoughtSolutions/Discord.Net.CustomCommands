using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Discord.Net.CustomCommands
{
    /// <summary>
    ///     Parses a list of inputs to types
    /// </summary>
    public class ContextParser<TContext>
    {
        private readonly IDictionary<Type, ITypeParser<TContext>> typeReaders;

        public ContextParser(IDictionary<Type, ITypeParser<TContext>> typeReaders)
        {
            this.typeReaders = typeReaders;
        }

        public async Task<T> Parse<T>(TContext context, IReadOnlyList<string> inputs) where T : class, new()
        {
            var specificContext = new T();
            var infos = typeof(T).GetProperties();

            for (var index = 0; index < infos.Length; index++)
            {
                var propertyInfo = infos[index];
                var input = inputs[index];

                await ParseInputToProperty(context, input, propertyInfo, specificContext);
            }

            return null;
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private async Task ParseInputToProperty<T>(TContext context, string input, PropertyInfo propertyInfo,
            T specificContext)
        {
            var typeParser = typeReaders[propertyInfo.PropertyType.BaseType];

            var targetType = IsNullableType(propertyInfo.PropertyType)
                ? Nullable.GetUnderlyingType(propertyInfo.PropertyType)
                : propertyInfo.PropertyType;

            if (typeParser == null)
            {
                propertyInfo.SetValue(specificContext, Convert.ChangeType(null, targetType), null);
                return;
            }

            propertyInfo.SetValue(specificContext,
                Convert.ChangeType(await typeParser.ParseAsync(context, input), targetType), null);
        }
    }
}