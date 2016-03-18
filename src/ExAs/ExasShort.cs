using ExAs.Assertions;
using ExAs.Results;

namespace ExAs
{
    public static class ExasShort
    {
        public static void ExAssert<T>(T instance, IAssert<T> assertion)
        {
            ObjectAssertionResult result = Evaluate(instance, assertion);
            if (result.succeeded)
                return;
            throw new ExtendedAssertionException(result);
        }

        public static ObjectAssertionResult Evaluate<T>(T instance, IAssert<T> assertion)
        {
            return assertion.Assert(instance);
        }

        public static IAssert<T> IsNotNull<T>()
        {
            return new ObjectAssertion<T>().IsNotNull();
        }

        public static IAssert<T> IsNull<T>()
        {
            return new ObjectAssertion<T>().IsNull();
        } 

        public static IAssert<T> Has<T>()
        {
            return new ObjectAssertion<T>();
        } 
    }
}