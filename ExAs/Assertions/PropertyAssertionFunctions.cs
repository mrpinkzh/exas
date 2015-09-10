using System;
using System.Linq.Expressions;
using ExAs.Results;
using ToText.Core;

namespace ExAs.Assertions
{
    public static class PropertyAssertionFunctions
    {
        public static PropertyAssertionResult Assert<TType, TPropertyType>(TType instance,
            Expression<Func<TType, TPropertyType>> propertExpression, IAssertValue<TPropertyType> assertion)
        {
            string propertyName = propertExpression.ExtractMemberName();
            if (assertion == null)
                return new PropertyAssertionResult(propertyName,
                                                   new ValueAssertionResult(false,
                                                                            "no assertion specified",
                                                                            string.Empty));
            TPropertyType value = propertExpression.Compile()(instance);
            ValueAssertionResult result = assertion.AssertValue(value);
            return new PropertyAssertionResult(propertyName, result);
        }
    }
}