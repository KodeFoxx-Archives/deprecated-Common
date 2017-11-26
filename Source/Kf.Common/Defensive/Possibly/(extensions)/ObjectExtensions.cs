using System;

namespace Kf.Common.Defensive.Possibly
{
    public static class ObjectExtensions
    {
        public static IPossible<TConcrete> ToPossible<TConcrete>(
            this TConcrete value, Func<TConcrete, bool> hasValueDeterminator = null
        ) => Possible.From(value, hasValueDeterminator);
    }
}
