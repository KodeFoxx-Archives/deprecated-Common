using System;
using System.Linq.Expressions;
using System.Reflection;
using Kf.Common.Defensive.Possibly;

namespace Kf.Common.Reflection
{
    public static class PropertyInfoHelper
    {
        public static IPossible<PropertyInfo> GetPropertyInfo<TObject, TProperty>(Expression<Func<TObject, TProperty>> propertySelector)
        {
            PropertyInfo propertyInfo = null;

            if (propertySelector.Body is MemberExpression memberExpression)
                propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertySelector.Body is UnaryExpression unaryExpression)
                propertyInfo = (unaryExpression.Operand as MemberExpression)?.Member as PropertyInfo;            

            return propertyInfo.ToPossible();
        }
    }
}
