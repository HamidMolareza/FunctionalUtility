using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
    public static class OnFailExtensions {

        #region OnFail

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                ErrorDetail errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail);

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Func<ErrorDetail> errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail ());

        public static MethodResult OnFail (
                this MethodResult @this,
                ErrorDetail errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail);

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<ErrorDetail> errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail ());

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Func<MethodResult<T>, MethodResult<T>> fail) =>
            @this.IsSuccess ?
            @this : fail (@this);

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Func<MethodResult<T>> fail) =>
            @this.IsSuccess ?
            @this : fail ();

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<MethodResult, MethodResult> fail) =>
            @this.IsSuccess ?
            @this : fail (@this);

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<MethodResult> fail) =>
            @this.IsSuccess ?
            @this : fail ();

        public static MethodResult OnFail (
                this MethodResult @this,
                Action fail) =>
            @this.IsSuccess ?
            @this : @this.Tee (fail);

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Action<MethodResult<T>> fail) =>
            @this.IsSuccess ?
            @this : @this.Tee (fail);

        #endregion

        #region OnFailOperateWhen

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnFail (() => OperateExtensions.OperateWhen (predicate (), operation));

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFail (() => @this.OperateWhen (predicate (), operation));

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation
        ) => @this.OnFail (result => predicate (result) ? operation (result) : @this);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation
        ) => @this.OnFail (result => predicate () ? operation (result) : @this);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFail (result => predicate (result) ? operation () : @this);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnFail (result => predicate (result) ? operation () : @this);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Func<MethodResult, MethodResult> operation
        ) => @this.OnFail (result => predicate () ? operation (result) : @this);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult, MethodResult> operation
        ) => @this.OnFail (result => predicate (result) ? operation (result) : @this);

        #endregion

        #region OnFailOperateWhenAsync

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<Task<MethodResult>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            if (predicate ())
                return await operation ();
            return methodResult;
        }

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate () ? operation () : methodResult;
        }

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnFailAsync (() => @this.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>, Task<MethodResult<T>>> operation
        ) => @this.OnFailAsync (result => predicate (result) ? operation (result) : @this);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<MethodResult<T>, Task<MethodResult<T>>> operation
        ) => @this.OnFailAsync (result => predicate () ? operation (result) : @this);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnFailAsync (result => predicate (result) ? operation () : @this);

        public static Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, bool> predicate,
            Func<Task<MethodResult>> operation
        ) => @this.OnFailAsync (result => predicate (result) ? operation () : @this);

        public static Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<MethodResult, Task<MethodResult>> operation
        ) => @this.OnFailAsync (result => predicate () ? operation (result) : @this);

        public static Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult, Task<MethodResult>> operation
        ) => @this.OnFailAsync (result => predicate (result) ? operation (result) : @this);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFailAsync (methodResult => methodResult.OperateWhen (predicate, operation));

        public static async Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult) ? operation (methodResult) : methodResult;
        }

        public static async Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate () ? operation (methodResult) : methodResult;
        }

        public static async Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult) ? operation () : methodResult;
        }

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult) ? operation () : methodResult;
        }

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<MethodResult, MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate () ? operation (methodResult) : methodResult;
        }

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult, MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult) ? operation (methodResult) : methodResult;
        }

        #endregion

        #region OnFailAsync

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult<TResult>>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>, Task<MethodResult<TResult>>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask (methodResult);

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>, MethodResult<TResult>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask (methodResult);

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TResult>> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<Task<MethodResult>> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? MethodResult.Ok () : await onFailTask ();
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, Task<MethodResult>> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? MethodResult.Ok () : await onFailTask (methodResult);
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? MethodResult.Ok () : onFailTask (methodResult);
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? MethodResult.Ok () : onFailTask ();
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Action onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<T>> OnFailAsync<T> (
            this Task<MethodResult<T>> @this,
            Action onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<T>> OnFailAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<Task> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<T>> OnFailAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, Task> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask (methodResult);

            return methodResult;
        }

        #endregion

    }
}