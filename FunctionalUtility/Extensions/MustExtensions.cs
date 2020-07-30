using System;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class MustExtensions {
        public static MethodResult<T> Must<T> (
            this T @this,
            bool predicate,
            ResultDetail errorDetail
        ) => @this.OperateWhen (!predicate,
            () => MethodResult<T>.Fail (errorDetail));
        
        public static MethodResult<T> Must<T> (
            this T @this,
            Func<bool> predicate,
            ResultDetail errorDetail
        ) => @this.OperateWhen (!predicate(),
            () => MethodResult<T>.Fail (errorDetail));
        
        public static MethodResult<T> Must<T> (
            this T @this,
            bool predicate,
            Func<ResultDetail> errorDetail
        ) => @this.OperateWhen (!predicate,
            () => MethodResult<T>.Fail (errorDetail()));
        
        public static MethodResult<T> Must<T> (
            this T @this,
            Func<bool> predicate,
            Func<ResultDetail> errorDetail
        ) => @this.OperateWhen (!predicate(),
            () => MethodResult<T>.Fail (errorDetail()));
    }
}