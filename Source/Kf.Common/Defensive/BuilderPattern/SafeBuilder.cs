using System.Collections.Generic;
using System.Linq;

namespace Kf.Common.Defensive.BuilderPattern
{
    public abstract class SafeBuilder<TObject, TBuilder> : Builder<TObject, TBuilder>, ISafeBuilder<TObject>
        where TBuilder : Builder<TObject, TBuilder>
        where TObject : class
    {
        public override TObject Build() {
            if(!CanBuild())
                throw new CanNotBuildException<TBuilder>(GetBuildErrors()?.ToList().ToArray());

            return base.Build();
        }

        public bool CanBuild()
            => (GetBuildErrors().ToList() ?? new List<string>()).Count == 0;
        public abstract IEnumerable<string> GetBuildErrors();
    }
}
