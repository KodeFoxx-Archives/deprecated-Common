using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kf.Common.Defensive.Possibly
{
    [DebuggerDisplay("{HasValue: " + nameof(HasValue) + "}")]
    public sealed class ConcreteValue<TConcrete> : Possible<TConcrete>
    {
        private readonly TConcrete _value;

        internal ConcreteValue(TConcrete value)
            => _value = value;

        public override bool HasValue => true;

        public override void Execute(Action<TConcrete> action)
            => action(_value);

        public override IPossible<TResult> Map<TResult>(Func<TConcrete, TResult> mapping)
            => Possible.Value(mapping(_value));

        public override TConcrete GetValue(Func<TConcrete> defaultValueProvider)
            => _value;

        public override TConcrete GetValue(TConcrete defaultValue)
            => defaultValue;

        public override IEnumerable<TConcrete> AsEnumerable()
            => new[] { _value };
    }
}
