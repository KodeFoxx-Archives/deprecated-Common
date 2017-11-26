using System;
using System.Collections.Generic;
using System.Linq;

namespace Kf.Common.Defensive.Possibly
{
    public static class IPossibleOfTExtensions
    {        
        public static IEnumerable<TConcrete> SelectElementsWithValue<TConcrete>(
            this IEnumerable<IPossible<TConcrete>> sequence
        ) => sequence != null 
                ? sequence.SelectMany(x => x.AsEnumerable())
                : Enumerable.Empty<TConcrete>();

        public static IEnumerable<TResult> MapElementsWithValue<TConcrete, TResult>(
            this IEnumerable<IPossible<TConcrete>> sequence, Func<TConcrete, IPossible<TResult>> mapping
        ) => sequence != null
                ? sequence
                    .SelectElementsWithValue()
                    .Select(mapping)
                    .SelectElementsWithValue()
                : Enumerable.Empty<TResult>();

        public static IEnumerable<IPossible<TConcrete>> Where<TConcrete>(
            this IEnumerable<IPossible<TConcrete>> sequence, Func<TConcrete, bool> filter
        ) => sequence != null
            ? sequence
                .SelectElementsWithValue()
                .Where(filter)
                .Select(v => v.ToPossible())
            : Enumerable.Empty<IPossible<TConcrete>>();

        public static IPossible<TConcrete> FirstOrNoValue<TConcrete>(
            this IEnumerable<IPossible<TConcrete>> sequence
        ) => sequence != null
                ? sequence.FirstOrDefault() ?? Possible.NoValue<TConcrete>()
                : Possible.NoValue<TConcrete>();
    }
}
