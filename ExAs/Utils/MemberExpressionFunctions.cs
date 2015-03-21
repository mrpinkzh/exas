using System.Linq.Expressions;

namespace ExAs.Utils
{
    public static class MemberExpressionFunctions
    {
        public static string ComposeMemberName(this MemberExpression expression)
        {
            var childExpression = expression.Expression as MemberExpression;
            if (childExpression == null)
                return expression.Member.Name;
            string composeMemberName = string.Format("{0}.{1}", childExpression.ComposeMemberName(), expression.Member.Name);
            return composeMemberName;
        }

        public static MemberExpression ExtractMemberExpression(this LambdaExpression expression)
        {
            if (expression == null)
                return null;
            Expression body = expression.Body;
            var memberExpression = body as MemberExpression;
            if (memberExpression != null)
                return memberExpression;
            var unaryExpression = body as UnaryExpression;
            if (unaryExpression != null)
                memberExpression = unaryExpression.Operand as MemberExpression;
            return memberExpression;
        }
    }
}