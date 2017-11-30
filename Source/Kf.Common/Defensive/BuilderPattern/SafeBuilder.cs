using System.Collections.Generic;

namespace Kf.Common.Defensive.BuilderPattern
{
    public abstract class SafeBuilder<TObject, TBuilder> : Builder<TObject, TBuilder>, ISafeBuilder<TObject>
        where TBuilder : Builder<TObject, TBuilder>
        where TObject : class
    {
        public override TObject Build() {
            if(!CanBuild())
                throw new CanNotBuildException<TBuilder>(GetBuildErrors()?.ToArray());

            return base.Build();
        }

        public bool CanBuild()
            => (GetBuildErrors() ?? new List<string>()).Count == 0;
        public abstract List<string> GetBuildErrors();
    }
}
