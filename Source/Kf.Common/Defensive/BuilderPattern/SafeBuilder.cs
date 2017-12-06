using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Kf.Common.Defensive.Possibly;
using Kf.Common.Reflection;

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

        protected bool HasValues()
            => _values != null || _values.Any();

        protected IPossible<TValue> GetValue<TValue, TProperty>(
            Expression<Func<TObject, TProperty>> propertySelector
        ) => HasValues()
                ? _values
                    .Where(kvp => kvp.Key.Name == PropertyInfoHelper
                                                    .GetPropertyInfo(propertySelector)
                                                    .Map(pi => pi.Name)
                                                    .GetValue(String.Empty)
                    )
                    .Select(kvp => (TValue)kvp.Value)
                    .FirstOrNoValue()
                : Possible.NoValue<TValue>();

        protected bool TryGetValue<TValue, TProperty>(
            Expression<Func<TObject, TProperty>> propertySelector, out TValue value
        ) {
            value = GetValue<TValue, TProperty>(propertySelector).GetValue(null);
            return value != null;
        }
    }
}
