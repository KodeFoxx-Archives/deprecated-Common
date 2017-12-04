using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Kf.Common.Defensive.BuilderPattern
{
    public abstract class Builder<TObject, TBuilder> : IBuilder<TObject>
        where TBuilder : Builder<TObject, TBuilder>
        where TObject : class
    {
        protected readonly Dictionary<PropertyInfo, object> _values = new Dictionary<PropertyInfo, object>();        

        public virtual TObject Build() {
            var @object = GetInsance();
            var errors = new List<string>();

            _values
                .Select(kvp => new { PropertyInfo = kvp.Key, Value = kvp.Value })
                .ToList().ForEach(kvp => {
                    try {
                        kvp.PropertyInfo.SetValue(@object, kvp.Value);
                    }
                    catch (Exception) {
                        errors.Add(
                            $"property {kvp.PropertyInfo.Name} could not be set with value {kvp.Value}"
                        );
                    }
                });

            if (errors.Any())
                throw new CanNotBuildException<TBuilder>(errors.ToArray());

            return @object;
        }        

        public TBuilder With<TProperty>(
            Expression<Func<TObject, TProperty>> propertySelector, TProperty value
        ) {
            var propertyInfo = GetPropertyInfo(propertySelector);
            _values[propertyInfo] = value;
            return this as TBuilder;
        }        

        private PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<TObject, TProperty>> propertySelector) {
            PropertyInfo propertyInfo = null;

            if (propertySelector.Body is MemberExpression memberExpression)
                propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertySelector.Body is UnaryExpression unaryExpression)
                propertyInfo = (unaryExpression.Operand as MemberExpression)?.Member as PropertyInfo;

            if(propertyInfo == null)
                throw new CanNotBuildException<TBuilder>(
                    $"Could not extract property from given propertySelector '{propertySelector}'."
                );

            return propertyInfo;
        }

        private TObject GetInsance()            
        {
            var constructor = typeof(TObject)
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(ctor => !ctor.GetParameters().Any());
            return constructor.Invoke(null) as TObject;
        }
    }
}
