using System;
using System.Collections.Generic;

namespace Kf.Common.Defensive.BuilderPattern
{
    public sealed class CanNotBuildException<TBuilder> : Exception
        where TBuilder : IBuilder
    {
        public CanNotBuildException(params string[] reasons)
            : base($"Can not build type because: {String.Join(", ", reasons ?? new List<string>().ToArray())}")
        { }
    }
}
