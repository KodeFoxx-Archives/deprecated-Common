using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kf.Common.Defensive.Possibly
{
    public static class Possible
    {
        public static IPossible<TConcrete> Value<TConcrete>(TConcrete value)
            => new ConcreteValue<TConcrete>(value);
        public static IPossible<TConcrete> NoValue<TConcrete>()
            => new NoValue<TConcrete>();
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
