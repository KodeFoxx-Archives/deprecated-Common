using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Kf.Common.Defensive.Possibly
{
    public static class Possible
    {
        public static IPossible<TConcrete> Value<TConcrete>(TConcrete value)
            => new ConcreteValue<TConcrete>(value);
        public static IPossible<TConcrete> NoValue<TConcrete>()
            => new NoValue<TConcrete>();

        public static IPossible<TConcrete> From<TConcrete>(
            TConcrete value, Func<TConcrete, bool> hasValueDeterminator) {
            if (hasValueDeterminator == null)
                return From(value, o => o != null);

            return hasValueDeterminator(value) 
                ? Value(value) 
                : NoValue<TConcrete>();
        }

        public static IPossible<string> From(
            string value,
            StringValueParserStrategy stringValueParserStrategy = StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
        ) {
            if (stringValueParserStrategy == StringValueParserStrategy.NullOrEmptyIsNoValue)
                return From(value, s => !String.IsNullOrEmpty(s));

            return From(value, s => !String.IsNullOrWhiteSpace(s));
        }

        public static IPossible<TConcrete> From<TConcrete>(TConcrete? value)
            where TConcrete : struct
            => value.HasValue
                ? Value(value.Value)
                : NoValue<TConcrete>();
    }

    [DebuggerDisplay("{HasValue: " + nameof(HasValue) + "}")]
    public abstract class Possible<TConcrete> : IPossible<TConcrete>
    {
        public abstract bool HasValue { get; }
        
        public abstract void Execute(Action<TConcrete> action);
          
        public abstract IPossible<TResult> Map<TResult>(Func<TConcrete, TResult> mapping);
        
        public abstract TConcrete GetValue(Func<TConcrete> defaultValueProvider);

        public abstract TConcrete GetValue(TConcrete defaultValue);
       
        public abstract IEnumerable<TConcrete> AsEnumerable();
    }
}
