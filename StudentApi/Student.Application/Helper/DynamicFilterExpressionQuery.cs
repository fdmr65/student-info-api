using StudentInfo.Application.Queries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace StudentInfo.Application.Helper
{
    public static class DynamicFilterExpressionQuery
    {
        public static Expression<Func<T, bool>> GetExpression<T>(IList<FilterQuery> filters)
        {
            if (filters == null || filters.Count == 0)
                return null;
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));
                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }

                }
            }
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }
        public static Expression GetExpression<T>(ParameterExpression param, FilterQuery filter)
        {
            var t = typeof(T);
            var field = t.GetProperties().ToList()
                .FirstOrDefault(item => item.Name.ToLower(new CultureInfo("en-US", false)) == filter.Field.ToLower(new CultureInfo("en-US", false)));

            filter.Field = field.Name;

            MemberExpression member = Expression.Property(param, filter.Field);
            var constant = Expression.Constant(filter.Value);

            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
            MethodInfo ensWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

            if (member.Type.Name == "DateTime")
            {
                filter.Value = Convert.ToDateTime(filter.Value.ToString());
                constant = Expression.Constant(filter.Value);
            }
            else if (member.Type.Name == "Int32")
            {
                filter.Value = Convert.ToInt32(filter.Value.ToString());
                constant = Expression.Constant(filter.Value);
            }
            else if (member.Type.Name == "Int64")
            {
                filter.Value = Convert.ToInt64(filter.Value.ToString());
                constant = Expression.Constant(filter.Value);
            }
            else if (member.Type.Name == "Boolean")
            {
                filter.Value = Convert.ToBoolean(filter.Value.ToString());
                constant = Expression.Constant(filter.Value);
            }
            else if (member.Type.Name == "Nullable`1")
            {
                string a = "Int32";
                string b = "DateTime";
                string c = "Decimal";

                if (member.Type.FullName.Contains(a) == true)
                {
                    if (filter.Operator != "isnull" && filter.Operator != "isnotnull")
                    {
                        object searchVal = Convert.ToInt32(filter.Value.ToString());
                        constant = Expression.Constant(searchVal, typeof(int?));
                    }
                }
                else if (member.Type.FullName.Contains(c) == true)
                {
                    if (filter.Operator != "isnull" && filter.Operator != "isnotnull")
                    {
                        object searchVal = Convert.ToDecimal(filter.Value.ToString());
                        constant = Expression.Constant(searchVal, typeof(decimal?));
                    }
                }
                else
                {
                    if (filter.Operator != "isnull" && filter.Operator != "isnotnull")
                    {
                        object searchVal = DateTime.Parse(filter.Value.ToString());
                        constant = Expression.Constant(searchVal, typeof(DateTime?));
                    }
                }
            }
            else
            {
                filter.Value = Convert.ToString(filter.Value);
                constant = Expression.Constant(filter.Value.ToString().ToUpper());
            }
            switch (filter.Operator)
            {
                case "eq":
                    return Expression.Equal(member, constant);
                case "neq":
                    return Expression.NotEqual(Expression.Call(member, "ToUpper", null), constant);
                case "contains":
                    return Expression.Call(Expression.Call(member, "ToUpper", null), containsMethod, constant);
                case "gt":
                    return Expression.GreaterThan(member, constant);
                case "gte":
                    return Expression.GreaterThanOrEqual(member, constant);
                case "lt":
                    return Expression.LessThan(member, constant);
                case "lte":
                    return Expression.LessThanOrEqual(member, constant);
                case "doesnotcontain":
                    return Expression.Not(Expression.Call(Expression.Call(member, "ToUpper", null), containsMethod, constant));
                case "startswith":
                    return Expression.Call(Expression.Call(member, "ToUpper", null), startsWithMethod, constant);
                case "endswith":
                    return Expression.Call(Expression.Call(member, "ToUpper", null), ensWithMethod, constant);
                case "isnull":
                    return Expression.Equal(member, Expression.Constant(null, member.Type));
                case "isnotnull":
                    return Expression.Not(Expression.Equal(member, Expression.Constant(null, member.Type)));
                case "isempty":
                    return Expression.Equal(member, Expression.Constant("", member.Type));
                case "isnotempty":
                    return Expression.Not(Expression.Equal(member, Expression.Constant("", member.Type)));

            }
            return null;
        }
        private static BinaryExpression GetExpression<T>(ParameterExpression param, FilterQuery filter1, FilterQuery filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);
            return Expression.AndAlso(bin1, bin2);
        }
    }
}
