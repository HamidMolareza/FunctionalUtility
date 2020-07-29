using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
    public static class MustExtensions {
        public static MethodResult<T> Must<T> (
            this T @this,
            bool predicate,
            ResultDetail errorDetail
        ) => @this.OperateWhen (!predicate,
            () => MethodResult<T>.Fail (errorDetail)
        );
    }
}