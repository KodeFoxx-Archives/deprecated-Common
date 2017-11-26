using System;
using System.Collections.Generic;
using System.Linq;

namespace Kf.Common.Defensive.Possibly
{
    public static class IPossibleOfTExtensions
    {
        /// <summary>
        /// Only returns those Possible objects that contain a value.
        /// </summary>        
        public static IEnumerable<TConcrete> SelectOnlyElementsWithValue<TConcrete>(
            this IEnumerable<IPossible<TConcrete>> sequence
        ) => sequence != null 
                ? sequence.SelectMany(x => x.AsEnumerable())
                : Enumerable.Empty<TConcrete>();

        public static IEnumerable<TResult> MapElementsWithValue<TConcrete, TResult>(
            this IEnumerable<TConcrete> sequence, Func<TConcrete, IPossible<TResult>> mapping
        ) => sequence != null
                ? sequence.Select(mapping).SelectOnlyElementsWithValue()
                : Enumerable.Empty<TResult>();
    }
}
