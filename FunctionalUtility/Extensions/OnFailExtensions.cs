using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
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

        public static MethodResult<T> OnFail<T> (
            this MethodResult<T> @this,
            object moreDetail) {
            if (!@this.IsSuccess)
                @this.Detail.AddDetail (moreDetail);
            return @this;
        }

        public static MethodResult OnFail (
                this MethodResult @this,
                ErrorDetail errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail);

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<ErrorDetail> errorDetail) =>
            @this.IsSuccess ? @this : @this.Fail (errorDetail ());

        public static MethodResult OnFail (
            this MethodResult @this,
            object moreDetail) {
            if (!@this.IsSuccess)
                @this.Detail.AddDetail (moreDetail);
            return @this;
        }

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Func<MethodResult<T>, MethodResult<T>> fail) =>
            @this.IsSuccess ? @this : fail (@this);

        public static MethodResult<T> OnFail<T> (
                this MethodResult<T> @this,
                Func<MethodResult<T>> fail) =>
            @this.IsSuccess ? @this : fail ();

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<MethodResult, MethodResult> fail) =>
            @this.IsSuccess ? @this : fail (@this);

        public static MethodResult OnFail (
                this MethodResult @this,
                Func<MethodResult> fail) =>
            @this.IsSuccess ? @this : fail ();

        public static MethodResult OnFail (
            this MethodResult @this,
            Action fail) {
            if (!@this.IsSuccess)
                fail ();
            return @this;
        }

        public static MethodResult OnFail (
            this MethodResult @this,
            Action<MethodResult> fail) {
            if (!@this.IsSuccess)
                fail (@this);
            return @this;
        }

        public static MethodResult<T> OnFail<T> (
            this MethodResult<T> @this,
            Action<MethodResult<T>> fail) {
            if (!@this.IsSuccess)
                fail (@this);
            return @this;
        }

        public static MethodResult<T> OnFail<T> (
            this MethodResult<T> @this,
            Action<T> fail) {
            if (!@this.IsSuccess)
                fail (@this.Value);
            return @this;
        }

        #endregion

        #region TryOnFail

        public static MethodResult<T> TryOnFail<T> (
            this MethodResult<T> @this,
            Func<ErrorDetail> errorDetail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => @this.Fail (errorDetail ()));
        }

        public static MethodResult TryOnFail (
            this MethodResult @this,
            ErrorDetail errorDetail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => @this.Fail (errorDetail));
        }

        public static MethodResult TryOnFail (
            this MethodResult @this,
            Func<ErrorDetail> errorDetail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => @this.Fail (errorDetail ()));
        }

        public static MethodResult<T> TryOnFail<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, MethodResult<T>> fail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => fail (@this));
        }

        public static MethodResult<T> TryOnFail<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>> fail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => fail ());
        }

        public static MethodResult TryOnFail (
            this MethodResult @this,
            Func<MethodResult, MethodResult> fail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => fail (@this));
        }

        public static MethodResult TryOnFail (
            this MethodResult @this,
            Func<MethodResult> fail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => fail ());
        }

        public static MethodResult TryOnFail (
            this MethodResult @this,
            Action fail) {
            if (@this.IsSuccess)
                return @this;

            return TryExtensions.Try (
                () => fail ());
        }

        public static MethodResult<T> TryOnFail<T> (
            this MethodResult<T> @this,
            Action<MethodResult<T>> fail) {
            if (@this.IsSuccess)
                return @this;

            try {
                fail (@this);
                return @this;
            } catch (Exception e) {
                return @this.Fail (new ExceptionError (e));
            }
        }

        #endregion

        #region OnFailOperateWhen

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnFailOperateWhen (predicate (), operation);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            bool predicate,
            Func<MethodResult> operation
        ) => @this.OnFail (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFailOperateWhen (predicate (), operation);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFail (() => @this.OperateWhen (predicate, operation));

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation
        ) => @this.OnFailOperateWhen (predicate (@this), operation);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<MethodResult<T>, MethodResult<T>> operation
        ) => @this.OnFailOperateWhen (predicate (), operation);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<MethodResult<T>, MethodResult<T>> operation
        ) => @this.OnFail (result => predicate ? operation (result) : @this);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFailOperateWhen (predicate (@this), operation);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnFailOperateWhen (predicate (@this), operation);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Func<MethodResult, MethodResult> operation
        ) => @this.OnFailOperateWhen (predicate (), operation);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            bool predicate,
            Func<MethodResult, MethodResult> operation
        ) => @this.OnFail (result => predicate ? operation (result) : @this);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult, MethodResult> operation
        ) => @this.OnFailOperateWhen (predicate (@this), operation);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            bool predicate,
            MethodResult result
        ) => @this.OnFail (result => predicate ? result : @this);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult> predicate,
            MethodResult result
        ) => @this.OnFailOperateWhen (predicate ().IsSuccess, result);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult> predicate,
            Func<MethodResult> result
        ) => @this.OnFailOperateWhen (predicate ().IsSuccess, result);

        public static MethodResult OnFailOperateWhen (
            this MethodResult @this,
            Func<MethodResult, MethodResult> predicate,
            MethodResult result
        ) => @this.OnFailOperateWhen (predicate (@this).IsSuccess, result);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            MethodResult<T> result
        ) => @this.OnFail (result => predicate ? result : @this);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            MethodResult<T> result
        ) => @this.OnFailOperateWhen (predicate ().IsSuccess, result);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, bool> predicate,
            MethodResult<T> result
        ) => @this.OnFailOperateWhen (predicate (@this), result);

        public static MethodResult<T> OnFailOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult<T>, MethodResult> predicate,
            MethodResult<T> result
        ) => @this.OnFailOperateWhen (predicate (@this).IsSuccess, result);

        #endregion

        #region OnFailOperateWhenAsync

        public static Task<MethodResult> OnFailOperateWhenAsync (
                this Task<MethodResult> @this,
                Func<bool> predicate,
                Func<Task<MethodResult>> operation) =>
            @this.OnFailOperateWhenAsync (predicate (), operation);

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<Task<MethodResult>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            if (predicate)
                return await operation ();
            return methodResult;
        }

        public static Task<MethodResult> OnFailOperateWhenAsync (
                this Task<MethodResult> @this,
                Func<bool> predicate,
                Func<MethodResult> operation) =>
            @this.OnFailOperateWhenAsync (predicate (), operation);

        public static Task<MethodResult> OnFailOperateWhenAsync (
                this Task<MethodResult> @this,
                Func<bool> predicate,
                MethodResult result) =>
            @this.OnFailOperateWhenAsync (predicate (), result);

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate ? operation () : methodResult;
        }

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            MethodResult result) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate ? result : methodResult;
        }

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnFailOperateWhenAsync (predicate (), operation);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
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
        ) => @this.OnFailOperateWhenAsync (predicate (), operation);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<MethodResult<T>, Task<MethodResult<T>>> operation
        ) => @this.OnFailAsync (result => predicate ? operation (result) : @this);

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
        ) => @this.OnFailOperateWhenAsync (predicate (), operation);

        public static Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<MethodResult, Task<MethodResult>> operation
        ) => @this.OnFailAsync (result => predicate ? operation (result) : @this);

        public static Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, bool> predicate,
            Func<MethodResult, Task<MethodResult>> operation
        ) => @this.OnFailAsync (result => predicate (result) ? operation (result) : @this);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnFailOperateWhenAsync (predicate (), operation);

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
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

        public static Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
                this Task<MethodResult<T>> @this,
                Func<bool> predicate,
                Func<MethodResult<T>, MethodResult<T>> operation) =>
            @this.OnFailOperateWhenAsync (predicate (), operation);

        public static async Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<MethodResult<T>, MethodResult<T>> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate ? operation (methodResult) : methodResult;
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
            Func<MethodResult, bool> predicate,
            MethodResult result) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult) ? result : methodResult;
        }

        public static Task<MethodResult> OnFailOperateWhenAsync (
                this Task<MethodResult> @this,
                Func<bool> predicate,
                Func<MethodResult, MethodResult> operation) =>
            @this.OnFailOperateWhenAsync (predicate (), operation);

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<MethodResult, MethodResult> operation) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate ? operation (methodResult) : methodResult;
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

        public static async Task<MethodResult> OnFailOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, MethodResult> predicate,
            MethodResult result) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult).IsSuccess ? result : methodResult;
        }

        public static async Task<MethodResult<T>> OnFailOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, MethodResult> predicate,
            MethodResult<T> result) {
            var methodResult = await @this;
            if (methodResult.IsSuccess)
                return methodResult;
            return predicate (methodResult).IsSuccess ? result : methodResult;
        }

        #endregion

        #region OnFailAsync

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            object moreDetail) {
            var t = await @this;
            if (!t.IsSuccess)
                t.Detail.AddDetail (moreDetail);
            return t;
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            object moreDetail) {
            var t = await @this;
            if (!t.IsSuccess)
                t.Detail.AddDetail (moreDetail);
            return t;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult<TSource>>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                return await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>, MethodResult<TSource>> onFailTask) {
            var methodResult = await @this;
            return !methodResult.IsSuccess ? onFailTask (methodResult) : methodResult;
        }

        public static async Task<MethodResult<TSource>> OnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>> onFailTask
        ) {
            var methodResult = await @this;
            return !methodResult.IsSuccess ? onFailTask () : methodResult;
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<Task<MethodResult>> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? methodResult : await onFailTask ();
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, Task<MethodResult>> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? methodResult : await onFailTask (methodResult);
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult, MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? methodResult : onFailTask (methodResult);
        }

        public static async Task<MethodResult> OnFailAsync (
            this Task<MethodResult> @this,
            Func<MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? methodResult : onFailTask ();
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
            Func<MethodResult<T>, Task<MethodResult<T>>> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                return await onFailTask (methodResult);

            return methodResult;
        }

        #endregion

        #region TeeOnFailAsync

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult<TResult>>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>, Task<MethodResult<TResult>>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask (methodResult);

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TSource>, MethodResult<TResult>> onFailTask) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask (methodResult);

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult<TResult>> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<TSource>> TeeOnFailAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<MethodResult> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<T>> TeeOnFailAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<Task> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask ();

            return methodResult;
        }

        public static async Task<MethodResult<T>> TeeOnFailAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult<T>, Task> onFailTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                await onFailTask (methodResult);

            return methodResult;
        }

        #endregion

        #region OnFailSuccessWhen

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, bool predicate) =>
            @this.OnFailOperateWhen (predicate, MethodResult.Ok);

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, Func<bool> predicate) =>
            @this.OnFailSuccessWhen (predicate ());

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, MethodResult predicate) =>
            @this.OnFailOperateWhen (predicate.IsSuccess, MethodResult.Ok);

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, Func<MethodResult, bool> predicate) =>
            @this.OnFailSuccessWhen (predicate (@this));

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, Func<MethodResult> predicate) =>
            @this.OnFailSuccessWhen (predicate ());

        public static MethodResult OnFailSuccessWhen (
                this MethodResult @this, Func<MethodResult, MethodResult> predicate) =>
            @this.OnFailSuccessWhen (predicate (@this));

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, bool predicate, T result) =>
            @this.OnFailOperateWhen (predicate, () => MethodResult<T>.Ok (result));

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, bool predicate, Func<T> result) =>
            @this.OnFailOperateWhen (predicate, () => MethodResult<T>.Ok (result ()));

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, MethodResult predicate, T result) =>
            @this.OnFailOperateWhen (predicate.IsSuccess, () => MethodResult<T>.Ok (result));

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, MethodResult predicate, Func<T> result) =>
            @this.OnFailOperateWhen (predicate.IsSuccess, () => MethodResult<T>.Ok (result ()));

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<bool> predicate, T result) =>
            @this.OnFailSuccessWhen (predicate (), result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult<T>, bool> predicate, T result) =>
            @this.OnFailSuccessWhen (predicate (@this), result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<bool> predicate, Func<T> result) =>
            @this.OnFailSuccessWhen (predicate (), result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult<T>, bool> predicate, Func<T> result) =>
            @this.OnFailSuccessWhen (predicate (@this), result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult> predicate, T result) =>
            @this.OnFailSuccessWhen (predicate ().IsSuccess, result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult<T>, MethodResult> predicate, T result) =>
            @this.OnFailSuccessWhen (predicate (@this).IsSuccess, result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult> predicate, Func<T> result) =>
            @this.OnFailSuccessWhen (predicate ().IsSuccess, result);

        public static MethodResult<T> OnFailSuccessWhen<T> (
                this MethodResult<T> @this, Func<MethodResult<T>, MethodResult> predicate, Func<T> result) =>
            @this.OnFailSuccessWhen (predicate (@this).IsSuccess, result);

        #endregion

        #region OnFailSuccessWhenAsync

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, bool predicate) =>
            @this.OnFailOperateWhenAsync (predicate, MethodResult.Ok);

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, MethodResult predicate) =>
            @this.OnFailOperateWhenAsync (predicate.IsSuccess, MethodResult.Ok);

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, Func<bool> predicate) =>
            @this.OnFailSuccessWhenAsync (predicate ());

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, Func<MethodResult, bool> predicate) =>
            @this.OnFailOperateWhenAsync (predicate, MethodResult.Ok);

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, Func<MethodResult> predicate) =>
            @this.OnFailSuccessWhenAsync (predicate ().IsSuccess);

        public static Task<MethodResult> OnFailSuccessWhenAsync (
                this Task<MethodResult> @this, Func<MethodResult, MethodResult> predicate) =>
            @this.OnFailOperateWhenAsync (predicate, MethodResult.Ok ());

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, bool predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, bool predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, bool predicate, Func<Task<T>> result) =>
            @this.OnFailOperateWhenAsync (predicate,
                async () => MethodResult<T>.Ok (await result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, MethodResult predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate.IsSuccess, () => MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, MethodResult predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate.IsSuccess, () => MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, MethodResult predicate, Func<Task<T>> result) =>
            @this.OnFailOperateWhenAsync (predicate.IsSuccess,
                async () => MethodResult<T>.Ok (await result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<bool> predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult<T>, bool> predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<bool> predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult<T>, bool> predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate, () => MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<bool> predicate, Func<Task<T>> result) =>
            @this.OnFailOperateWhenAsync (predicate,
                async () => MethodResult<T>.Ok (await result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult<T>, bool> predicate, Func<Task<T>> result) =>
            @this.OnFailOperateWhenAsync (predicate,
                async () => MethodResult<T>.Ok (await result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult> predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate ().IsSuccess, () => MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult<T>, MethodResult> predicate, T result) =>
            @this.OnFailOperateWhenAsync (predicate, MethodResult<T>.Ok (result));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult> predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate ().IsSuccess, () => MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult<T>, MethodResult> predicate, Func<T> result) =>
            @this.OnFailOperateWhenAsync (predicate, MethodResult<T>.Ok (result ()));

        public static Task<MethodResult<T>> OnFailSuccessWhenAsync<T> (
                this Task<MethodResult<T>> @this, Func<MethodResult> predicate, Func<Task<T>> result) =>
            @this.OnFailOperateWhenAsync (predicate ().IsSuccess,
                async () => MethodResult<T>.Ok (await result ()));

        #endregion

    }
}