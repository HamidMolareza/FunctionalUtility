using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class OperateExtensions {

        #region OperateWhen

        public static MethodResult OperateWhen (
            bool predicate,
            Func<MethodResult> function
        ) => predicate ? function () : MethodResult.Ok ();

        public static MethodResult OperateWhen (
            Func<bool> predicate,
            Func<MethodResult> function
        ) => predicate () ? function () : MethodResult.Ok ();

        public static MethodResult OperateWhen (
            Func<bool> predicate,
            Action action) {
            if (predicate ())
                action ();
            return MethodResult.Ok ();
        }

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<MethodResult<T>> function
        ) => predicate ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            Func<MethodResult<T>> operation
        ) => predicate ().IsSuccess ? operation () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<MethodResult<T>> function
        ) => predicate () ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<MethodResult> function
        ) => predicate ? function ().MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<MethodResult> function
        ) => predicate () ? function ().MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<MethodResult<T>> function
        ) => predicate (@this) ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<MethodResult> function
        ) => predicate (@this) ? function ().MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, MethodResult<T>> function
        ) => predicate ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, MethodResult<T>> function
        ) => predicate () ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, MethodResult> function
        ) => predicate ? function (@this).MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, MethodResult<T>> function
        ) => predicate (@this) ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, MethodResult> function
        ) => predicate (@this) ? function (@this).MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult OperateWhen (
            Func<MethodResult> predicate,
            Func<MethodResult> function
        ) => predicate ().IsSuccess ? function () : MethodResult.Ok ();

        public static MethodResult OperateWhen (
            Func<MethodResult> predicate,
            Action action
        ) {
            if (predicate ().IsSuccess)
                action ();
            return MethodResult.Ok ();
        }

        public static MethodResult OperateWhen (
            MethodResult predicate,
            Func<MethodResult> function
        ) => predicate.IsSuccess ? function () : MethodResult.Ok ();

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            Func<MethodResult<T>> function
        ) => predicate ().IsSuccess ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<MethodResult<T>> function
        ) => predicate (@this).IsSuccess ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            Func<T, MethodResult<T>> function
        ) => predicate ().IsSuccess ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<T, MethodResult<T>> function
        ) => predicate.IsSuccess ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<T, MethodResult<T>> function
        ) => predicate (@this).IsSuccess ? function (@this) : MethodResult<T>.Ok (@this);

        public static T OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T> function
        ) => predicate ? function () : @this;

        public static T OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T> function
        ) => predicate () ? function () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Action action) {
            if (predicate)
                action ();
            return MethodResult<T>.Ok (@this);
        }

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Action action) {
            if (predicate ())
                action ();
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T> function
        ) => predicate (@this) ? function () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action action) {
            if (predicate (@this))
                action ();
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, T> function
        ) => predicate? function (@this): @this;

        public static T OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, T> function
        ) => predicate () ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Action<T> action) {
            if (predicate)
                action (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Action<T> action) {
            if (predicate ())
                action (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, T> function
        ) => predicate (@this) ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action<T> action) {
            if (predicate (@this))
                action (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
                this T @this,
                MethodResult predicate,
                Func<T> function) =>
            predicate.IsSuccess ? function () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action action
        ) {
            if (predicate.IsSuccess)
                action ();
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T> function) =>
            predicate (@this).IsSuccess ? function () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) {
            if (predicate (@this).IsSuccess)
                action ();
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
                this T @this,
                MethodResult predicate,
                Func<T, T> function) =>
            predicate.IsSuccess ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) {
            if (predicate.IsSuccess)
                action (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T, T> function) =>
            predicate (@this).IsSuccess ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) {
            if (predicate (@this).IsSuccess)
                action (@this);
            return MethodResult<T>.Ok (@this);
        }

        #endregion

        #region OperateWhenAsync

        public static async Task OperateWhenAsync (
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function ();
        }

        public static async Task OperateWhenAsync (
            Func<bool> predicate,
            Func<Task> function) {
            if (predicate ())
                await function ();
        }

        public static async Task<MethodResult> OperateWhenAsync (
            Func<bool> predicate,
            Func<Task<MethodResult>> function) {
            if (predicate ())
                return await function ();
            return MethodResult.Ok ();
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<Task<T>> function) {
            var t = await @this;
            if (predicate)
                return await function ();
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<Task<T>> function) {
            var t = await @this;
            return predicate ? MethodResult<T>.Ok (await function ()) : t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function ();
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate)
                return await function (t);
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<T, Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function (t);
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate ())
                return await function (t);
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate ())
                return await function (t);
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate (t))
                return await function (t);
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate (t))
                return await function (t);
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate ? function (t) : t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<T, MethodResult<T>> function) {
            var t = await @this;
            return predicate ? function (t) : MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate () ? function (t) : t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, MethodResult<T>> function) {
            var t = await @this;
            return predicate () ? function (t) : MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate (t) ? function (t) : t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, MethodResult<T>> function) {
            var t = await @this;
            return predicate (t) ? function (t) : MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<Task<T>> function) {
            var t = await @this;
            if (predicate ())
                return await function ();
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            Func<bool> predicate,
            Func<Task<T>> function) {
            var t = await @this;
            return predicate () ? MethodResult<T>.Ok (await function ()) : t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate ())
                return await function ();
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<Task<T>> function) {
            var t = await @this;
            if (predicate (t))
                return await function ();
            return t;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate (t))
                return await function ();
            return MethodResult<T>.Ok (t);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task<T>> function) {
            if (predicate)
                return await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
                this MethodResult<T> @this,
                bool predicate,
                Func<Task<T>> function) =>
            predicate ? MethodResult<T>.Ok (await function ()) : @this;

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate)
                return await function ();
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate)
                return await function ();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<Task<T>> function) {
            if (predicate ())
                return await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
                this MethodResult<T> @this,
                Func<bool> predicate,
                Func<Task<T>> function) =>
            predicate () ? MethodResult<T>.Ok (await function ()) : @this;

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate ())
                return await function ();
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate ())
                return await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function ();
            return t;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<Task<T>> function) {
            if (predicate (@this))
                return await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate (@this))
                return await function ();
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task<T>> function) {
            if (predicate)
                return await function (@this);
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task<MethodResult<T>>> function) {
            if (predicate)
                return await function (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) {
            if (predicate ())
                return await function (@this);
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, Task<MethodResult<T>>> function) {
            if (predicate ())
                return await function (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> function) {
            if (predicate (@this))
                return await function (@this);
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task<MethodResult<T>>> function) {
            if (predicate (@this))
                return await function (@this);
            return MethodResult<T>.Ok (@this);
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<Task<T>> function) {
            if (predicate (@this).IsSuccess)
                return await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<Task<MethodResult<T>>> function) {
            if (predicate (@this).IsSuccess)
                return await function ();
            return MethodResult<T>.Ok (@this);
        }

        #endregion

        #region TeeOperateWhen

        public static MethodResult<T> TeeOperateWhen<T> (
            this T @this,
            bool predicate,
            Func<MethodResult> function
        ) => predicate ? function ().MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<MethodResult> function
        ) {
            if (predicate.IsSuccess)
                function ();
            return MethodResult<T>.Ok (@this);
        }

        public static T TeeOperateWhen<T> (
            this T @this,
            bool predicate,
            Action action
        ) => predicate ? @this.Tee (action) : @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action action
        ) => predicate (@this) ? @this.Tee (action) : @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            bool predicate,
            Action<T> action
        ) => predicate? @this.Tee (action): @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action<T> action
        ) => predicate (@this) ? @this.Tee (action) : @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action action
        ) {
            if (predicate.IsSuccess)
                action ();
            return @this;
        }

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) {
            if (predicate (@this).IsSuccess)
                action ();
            return @this;
        }

        public static T TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) {
            if (predicate.IsSuccess)
                action (@this);
            return @this;
        }

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) {
            if (predicate (@this).IsSuccess)
                action (@this);
            return @this;
        }

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> TeeOperateWhenAsync<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function ();
            return @this;
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this TSource @this,
            bool predicate,
            Func<Task<TResult>> function) {
            if (predicate)
                await function ();
            return MethodResult<TSource>.Ok (@this);
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            bool predicate,
            Func<Task<TResult>> function) {
            if (predicate)
                await function ();
            return @this;
        }

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<Task> function) {
            if (predicate ())
                await function ();
            return @this;
        }

        public static async Task<MethodResult<T>> TeeOperateWhenAsync<T> (
            this MethodResult<T> @this,
            Func<bool> predicate,
            Func<Task> function) {
            if (predicate ())
                await function ();
            return @this;
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this TSource @this,
            Func<bool> predicate,
            Func<Task<TResult>> function) {
            if (predicate ())
                await function ();
            return MethodResult<TSource>.Ok (@this);
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<bool> predicate,
            Func<Task<TResult>> function) {
            if (predicate ())
                await function ();
            return @this;
        }

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<Task> function) {
            if (predicate (@this))
                await function ();
            return @this;
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, bool> predicate,
            Func<Task<TResult>> function) {
            if (predicate (@this))
                await function ();
            return MethodResult<TSource>.Ok (@this);
        }

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task> function) {
            if (predicate)
                await function (@this);
            return @this;
        }

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, Task> function) {
            if (predicate ())
                await function (@this);
            return @this;
        }

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this TSource @this,
            Func<bool> predicate,
            Func<TSource, Task<TResult>> function) {
            if (predicate ())
                await function (@this);
            return MethodResult<TSource>.Ok (@this);
        }

        #endregion

    }
}