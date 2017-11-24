using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kf.Common.Defensive.Possibly
{
    [DebuggerDisplay("{HasValue: " + nameof(HasValue) + "}")]
    public sealed class NoValue<TConcrete> : Possible<TConcrete>
    {
        internal NoValue() { }

        public override bool HasValue => false;        

        public override void Execute(Action<TConcrete> action) { }

        public override IPossible<TResult> Map<TResult>(Func<TConcrete, TResult> mapping)
            => Possible.NoValue<TResult>();

        public override TConcrete GetValue(Func<TConcrete> defaultValueProvider)
            => defaultValueProvider();

        public override TConcrete GetValue(TConcrete defaultValue)
            => defaultValue;

        public override IEnumerable<TConcrete> AsEnumerable()
            => Enumerable.Empty<TConcrete>();
    }
}
