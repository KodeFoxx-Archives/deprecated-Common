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
            => (GetBuildErrors()?.ToList() ?? new List<string>()).Count == 0;
        public abstract IEnumerable<string> GetBuildErrors();

        protected bool HasValues()
            => _values != null && _values.Any();

        protected bool IsPropertySet<TValue>(Expression<Func<TObject, TValue>> propertySelector) {
            if (!HasValues()) return false;
            var propertyName = PropertyInfoHelper.GetPropertyNameOrEmptyString(propertySelector);
            return _values.Keys
                .Any(pi => pi.Name == propertyName);
        }            

        protected IPossible<TValue> GetValue<TValue>(
            Expression<Func<TObject, TValue>> propertySelector
        ) => HasValues() && IsPropertySet(propertySelector)
                ? _values
                    .Where(kvp => kvp.Key.Name == PropertyInfoHelper.GetPropertyNameOrEmptyString(propertySelector))
                    .Select(kvp => (TValue)kvp.Value)
                    .FirstOrNoValue()
                : Possible.NoValue<TValue>();        

        protected bool TryGetValue<TValue>(
            Expression<Func<TObject, TValue>> propertySelector, out TValue value
        ) {
            if (!IsPropertySet(propertySelector)) {
                value = default(TValue);
                return false;                
            }

            value = GetValue(propertySelector).GetValue(() => default(TValue));            
            return value != null;
        }
    }
}
