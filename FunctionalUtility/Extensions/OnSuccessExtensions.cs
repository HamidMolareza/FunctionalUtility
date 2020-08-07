using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class OnSuccessExtensions {

        #region OnSuccess

        public static MethodResult<TResult> OnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                TResult successResult) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (successResult) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TResult> (
                this MethodResult @this,
                TResult successResult) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (successResult) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, MethodResult<TResult>> success) =>
            @this.IsSuccess ?
            success (@this.Value) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<MethodResult<TResult>> success) =>
            @this.IsSuccess ?
            success () :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TResult> (
                this MethodResult @this,
                Func<MethodResult<TResult>> success) =>
            @this.IsSuccess ?
            success () :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult OnSuccess<TSource> (
                this MethodResult<TSource> @this,
                Func<TSource, MethodResult> success) =>
            @this.IsSuccess ?
            success (@this.Value) :
            MethodResult.Fail (@this.Detail);

        public static MethodResult OnSuccess<TSource> (
                this MethodResult<TSource> @this,
                Func<MethodResult> success) =>
            @this.IsSuccess ? success () : MethodResult.Fail (@this.Detail);

        public static MethodResult OnSuccess (
                this MethodResult @this,
                Func<MethodResult> success) =>
            @this.IsSuccess ?
            success () :
            MethodResult.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> success) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (success (@this.Value)) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> success) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (success ()) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> OnSuccess<TResult> (
                this MethodResult @this,
                Func<TResult> success) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (success ()) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult OnSuccess<TSource> (
            this MethodResult<TSource> @this,
            Action<TSource> success) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            success (@this.Value);
            return MethodResult.Ok ();
        }

        public static MethodResult OnSuccess<TSource> (
            this MethodResult<TSource> @this,
            Action success) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            success ();
            return MethodResult.Ok ();
        }

        public static MethodResult OnSuccess (
            this MethodResult @this,
            Action success) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            success ();
            return MethodResult.Ok ();
        }

        #endregion

        #region OnSuccessAsync

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<MethodResult<TResult>>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask (methodResult.Value) :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<TResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                MethodResult<TResult>.Ok (await onSuccessTask (methodResult.Value)) :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult<TResult>>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask () :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<TResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                MethodResult<TResult>.Ok (await onSuccessTask ()) :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<MethodResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask (methodResult.Value) :
                MethodResult.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task> onSuccessTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                return MethodResult.Fail (methodResult.Detail);

            await onSuccessTask (methodResult.Value);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask () :
                MethodResult.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task> onSuccessTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                return MethodResult.Fail (methodResult.Detail);

            await onSuccessTask ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
            this Task<MethodResult> @this,
            Func<Task<MethodResult<TResult>>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask () :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
            this Task<MethodResult> @this,
            Func<Task<TResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                MethodResult<TResult>.Ok (await onSuccessTask ()) :
                MethodResult<TResult>.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult> OnSuccessAsync (
            this Task<MethodResult> @this,
            Func<Task<MethodResult>> onSuccessTask
        ) {
            var methodResult = await @this;
            return methodResult.IsSuccess ?
                await onSuccessTask () :
                MethodResult.Fail (methodResult.Detail);
        }

        public static async Task<MethodResult> OnSuccessAsync (
            this Task<MethodResult> @this,
            Func<Task> onSuccessTask
        ) {
            var methodResult = await @this;
            if (!methodResult.IsSuccess)
                return MethodResult.Fail (methodResult.Detail);

            await onSuccessTask ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, Task<MethodResult<TResult>>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask (@this.Value) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, Task<TResult>> onSuccessTask
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (await onSuccessTask (@this.Value)) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<Task<MethodResult<TResult>>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask () :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<Task<TResult>> onSuccessTask
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (await onSuccessTask ()) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
                this MethodResult<TSource> @this,
                Func<TSource, Task<MethodResult>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask (@this.Value) :
            MethodResult.Fail (@this.Detail);

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<TSource, Task> onSuccessTask) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            await onSuccessTask (@this.Value);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
                this MethodResult<TSource> @this,
                Func<Task<MethodResult>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask () :
            MethodResult.Fail (@this.Detail);

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<Task> onSuccessTask) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            await onSuccessTask ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
                this MethodResult @this,
                Func<Task<MethodResult<TResult>>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask () :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
                this MethodResult @this,
                Func<Task<TResult>> onSuccessTask) =>
            @this.IsSuccess ?
            MethodResult<TResult>.Ok (await onSuccessTask ()) :
            MethodResult<TResult>.Fail (@this.Detail);

        public static async Task<MethodResult> OnSuccessAsync (
                this MethodResult @this,
                Func<Task<MethodResult>> onSuccessTask
            ) => @this.IsSuccess ?
            await onSuccessTask () :
            MethodResult.Fail (@this.Detail);

        public static async Task<MethodResult> OnSuccessAsync (
            this MethodResult @this,
            Func<Task> onSuccessTask) {
            if (!@this.IsSuccess)
                return MethodResult.Fail (@this.Detail);
            await onSuccessTask ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult<TResult>> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult> OnSuccessAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult<TResult>> OnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        public static async Task<MethodResult> OnSuccessAsync (
                this Task<MethodResult> @this,
                Func<MethodResult> onSuccessTask
            ) => (await @this)
            .OnSuccess (onSuccessTask);

        #endregion

        #region TryOnSuccess

        public static MethodResult<TResult> TryOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> success) =>
            @this.OnSuccess (source => source.Try (success));

        public static MethodResult<TResult> TryOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        public static MethodResult<TResult> TryOnSuccess<TResult> (
                this MethodResult @this,
                Func<TResult> success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        public static MethodResult<TResult> TryOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, MethodResult<TResult>> success) =>
            @this.OnSuccess (source => source.Try (success));

        public static MethodResult<TResult> TryOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<MethodResult<TResult>> success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        public static MethodResult<TResult> TryOnSuccess<TResult> (
                this MethodResult @this,
                Func<MethodResult<TResult>> success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        public static MethodResult TryOnSuccess<TSource> (
                this MethodResult<TSource> @this,
                Action<TSource> success) =>
            @this.OnSuccess (source => source.Try (success));

        public static MethodResult TryOnSuccess<TSource> (
                this MethodResult<TSource> @this,
                Action success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        public static MethodResult TryOnSuccess (
                this MethodResult @this,
                Action success) =>
            @this.OnSuccess (() => TryExtensions.Try (success));

        #endregion

        #region TryOnSuccessAsync

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<Task<TResult>> success,
                int numOfTry) =>
            @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<Task<MethodResult<TResult>>> success,
                int numOfTry = 1) =>
            @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<TResult>> success,
            int numOfTry
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<MethodResult<TResult>>> success,
            int numOfTry
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<TResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult<TResult>>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Func<Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync (
            this Task<MethodResult> @this,
            Func<Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync (
            this Task<MethodResult> @this,
            Func<Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TSource, TResult> success
        ) => @this.OnSuccessAsync (source => source.Try (success));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this Task<MethodResult<TSource>> @this,
            Func<TResult> success
        ) => @this.OnSuccessAsync (() => TryExtensions.Try (success));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Action<TSource> success
        ) => @this.OnSuccessAsync (source => source.Try (success));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this Task<MethodResult<TSource>> @this,
            Action success
        ) => @this.OnSuccessAsync (() => TryExtensions.Try (success));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TResult> (
            this Task<MethodResult> @this,
            Func<TResult> success
        ) => @this.OnSuccessAsync (() => TryExtensions.Try (success));

        public static Task<MethodResult> TryOnSuccessAsync (
            this Task<MethodResult> @this,
            Action success
        ) => @this.OnSuccessAsync (() => TryExtensions.Try (success));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TResult> (
                this MethodResult @this,
                Func<Task<TResult>> success,
                int numOfTry = 1) =>
            @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, Task<TResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<Task<TResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<TSource, Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync (
            this MethodResult @this,
            Func<Task> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TResult> (
                this MethodResult @this,
                Func<Task<MethodResult<TResult>>> success,
                int numOfTry = 1) =>
            @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, Task<MethodResult<TResult>>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult<TResult>> TryOnSuccessAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<Task<MethodResult<TResult>>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<TSource, Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (source => source.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync<TSource> (
            this MethodResult<TSource> @this,
            Func<Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        public static Task<MethodResult> TryOnSuccessAsync (
            this MethodResult @this,
            Func<Task<MethodResult>> success,
            int numOfTry = 1
        ) => @this.OnSuccessAsync (() => TryExtensions.TryAsync (success, numOfTry));

        #endregion

        #region OnSuccessFailWhen

        public static MethodResult OnSuccessFailWhen (
            this MethodResult @this,
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate () ? MethodResult.Fail (errorDetail) : @this);

        public static MethodResult OnSuccessFailWhen (
            this MethodResult @this,
            bool predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate ? MethodResult.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (source => predicate (source) ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate (source) ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate () ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate () ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        public static MethodResult OnSuccessFailWhen (
            this MethodResult @this,
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate ().IsSuccess ? MethodResult.Fail (errorDetail) : @this);

        public static MethodResult OnSuccessFailWhen (
            this MethodResult @this,
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate.IsSuccess ? MethodResult.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<T, MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (source => predicate (source).IsSuccess ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<T, MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate (source).IsSuccess ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate ().IsSuccess ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate ().IsSuccess ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccess (() => predicate.IsSuccess ? MethodResult<T>.Fail (errorDetail) : @this);

        public static MethodResult<T> OnSuccessFailWhen<T> (
            this MethodResult<T> @this,
            MethodResult predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccess (source => predicate.IsSuccess ? MethodResult<T>.Fail (errorDetail (source)) : @this);

        #endregion

        #region OnSuccessFailWhenAsync

        public static Task<MethodResult> OnSuccessFailWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (() => predicate () ? MethodResult.Fail (errorDetail) : MethodResult.Ok ());

        public static Task<MethodResult> OnSuccessFailWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (() => predicate ? MethodResult.Fail (errorDetail) : MethodResult.Ok ());

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate (source) ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate (source) ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate () ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate () ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        public static Task<MethodResult> OnSuccessFailWhenAsync (
            this Task<MethodResult> @this,
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (() => predicate ().IsSuccess ? MethodResult.Fail (errorDetail) : MethodResult.Ok ());

        public static Task<MethodResult> OnSuccessFailWhenAsync (
            this Task<MethodResult> @this,
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (() => predicate.IsSuccess ? MethodResult.Fail (errorDetail) : MethodResult.Ok ());

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate (source).IsSuccess ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate (source).IsSuccess ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate ().IsSuccess ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate ().IsSuccess ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => @this.OnSuccessAsync (source => predicate.IsSuccess ?
            MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (source));

        public static Task<MethodResult<T>> OnSuccessFailWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            MethodResult predicate,
            Func<T, ErrorDetail> errorDetail
        ) => @this.OnSuccessAsync (source => predicate.IsSuccess ?
            MethodResult<T>.Fail (errorDetail (source)) : MethodResult<T>.Ok (source));

        #endregion

        #region OnSuccessOperateWhen

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (() => @this.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (predicate (value), operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (predicate, () => operation (value)));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (
            predicate (value), () => operation (value)));

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            Func<bool> predicate,
            Action operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            bool predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (() => @this.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (predicate, () => operation (value)));

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            Func<MethodResult> predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (() => @this.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<T, MethodResult> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (value => value.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.Value.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            Func<T, MethodResult> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (
            predicate (value), () => operation (value)));

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            Func<MethodResult> predicate,
            Action operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult OnSuccessOperateWhen (
            this MethodResult @this,
            MethodResult predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccess (() => OperateExtensions.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            MethodResult predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccess (() => @this.OperateWhen (predicate, operation));

        public static MethodResult<T> OnSuccessOperateWhen<T> (
            this MethodResult<T> @this,
            MethodResult predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccess (value => @this.OperateWhen (predicate, () => operation (value)));

        #endregion

        #region OnSuccessOperateWhenAsync

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccessAsync (() => OperateExtensions.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<T, T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<T, T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate (source), operation));

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<MethodResult> operation
        ) => @this.OnSuccessAsync (() => OperateExtensions.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<T, MethodResult<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<T, T> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhen (predicate, operation));

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this MethodResult @this,
            Func<bool> predicate,
            Func<Task<MethodResult>> operation
        ) => @this.OnSuccessAsync (() => @this.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (() => @this.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => @this.OperateWhenAsync (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => @this.OperateWhenAsync (predicate, () => operation (source)));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => @this.OperateWhenAsync (predicate (source), () => operation (source)));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<Task<T>> operation
        ) => @this.OnSuccessAsync (source => @this.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<Task<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<T, Task<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate (source), operation));

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this MethodResult @this,
            bool predicate,
            Func<Task<MethodResult>> operation
        ) => @this.OnSuccessAsync (() => @this.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<Task<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<T, Task<T>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this Task<MethodResult> @this,
            Func<bool> predicate,
            Func<Task<MethodResult>> operation
        ) => @this.OnSuccessAsync (() => OperateExtensions.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate (source), operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<T, bool> predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate (source), operation));

        public static Task<MethodResult> OnSuccessOperateWhenAsync (
            this Task<MethodResult> @this,
            bool predicate,
            Func<Task<MethodResult>> operation
        ) => @this.OnSuccessAsync (() => OperateExtensions.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        public static Task<MethodResult<T>> OnSuccessOperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<T, Task<MethodResult<T>>> operation
        ) => @this.OnSuccessAsync (source => source.OperateWhenAsync (predicate, operation));

        #endregion

    }
}