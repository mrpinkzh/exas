using System;
using System.Linq.Expressions;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions
{
    public static class PropertyAssertionFunctions
    {
        public static PropertyAssertionResult Assert<TType, TPropertyType>(TType instance,
            Expression<Func<TType, TPropertyType>> propertExpression, IAssertValue<TPropertyType> assertion)
        {
            string memberName = propertExpression.ExtractMemberName();
            TPropertyType value = propertExpression.Compile()(instance);
            return Assert(assertion, memberName, value);
        }

        public static PropertyAssertionResult Assert<TPropertyType>(IAssertValue<TPropertyType> assertion, string memberName,
            TPropertyType value)
        {
            if (assertion == null)
                return new PropertyAssertionResult(memberName,
                    new ValueAssertionResult(false,
                        "no assertion specified",
                        string.Empty));
            ValueAssertionResult result = assertion.AssertValue(value);
            return new PropertyAssertionResult(memberName, result);
        }
    }
}