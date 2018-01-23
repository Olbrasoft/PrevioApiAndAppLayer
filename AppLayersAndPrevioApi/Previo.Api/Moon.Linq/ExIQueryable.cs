using System;
using System.Linq;
using System.Linq.Expressions;

namespace Moon.Linq
{
    public static class ExIQueryable
    {
        private static bool IsSequenceOperator(string operatorName, MethodCallExpression mce)
        {
            return mce != null && mce.Method.DeclaringType == typeof(Queryable) &&
                   mce.Method.Name.Equals(operatorName, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsQueryOrder(this IQueryable query)
        {
            if (query == null) return false;

            var mce = query.Expression as MethodCallExpression;
            
            return IsSequenceOperator("OrderBy", mce) || IsSequenceOperator("OrderByDescending", mce)
                   || IsSequenceOperator("ThenBy", mce) || IsSequenceOperator("ThenByDescending", mce);
        }

    }
}
