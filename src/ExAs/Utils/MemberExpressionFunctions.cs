using System.Linq.Expressions;
using ExAs.Utils.StringExtensions;

namespace ExAs.Utils
{
    public static class MemberExpressionFunctions
    {
        public static string ExtractMemberName(this LambdaExpression expression)
        {
            if (expression == null)
                return string.Empty;
            Expression body = expression.Body;

            var memberExpression = body as MemberExpression;
            if (memberExpression != null)
                return memberExpression.ComposeMemberName();

            var unaryExpresson = body as UnaryExpression;
            if (unaryExpresson != null)
            {
                var operandMemberExpression = unaryExpresson.Operand as MemberExpression;
                return operandMemberExpression.ComposeMemberName();
            }

            var methodCallExpression = body as MethodCallExpression;
            if (methodCallExpression != null)
                return methodCallExpression.Method.Name.Add("()");

            return string.Empty;
        }

        public static string ComposeMemberName(this MemberExpression expression)
        {
            if (expression == null)
                return string.Empty;
            var childExpression = expression.Expression as MemberExpression;
            if (childExpression == null)
                return expression.Member.Name;
            string composeMemberName = string.Format("{0}.{1}", childExpression.ComposeMemberName(), expression.Member.Name);
            return composeMemberName;
        }
    }
}