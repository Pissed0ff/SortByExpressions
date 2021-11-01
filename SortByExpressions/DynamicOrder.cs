using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SortByExpressions
{
    public static class DynamicOrder
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> sourse, string property)
        {
            ParameterExpression xParam = Expression.Parameter(typeof(T), "x");
            Expression propertyParam = Expression.Property(xParam, property);
            var resultExpression = Expression.Lambda(propertyParam, xParam);

            var lambda = resultExpression.Compile();

            Type EnumerableType = typeof(Enumerable);
            var metods = EnumerableType.GetMethods(BindingFlags.Public | BindingFlags.Static);
            var selectMetod = metods.Where(m => m.Name == "OrderBy" && m.GetParameters().Count() == 2);
            var method = selectMetod.First();

            var result = (IEnumerable<T>)method.MakeGenericMethod(typeof(T), propertyParam.Type).Invoke(null, new object[] { sourse, lambda });
            return result;
        }
    }
}
