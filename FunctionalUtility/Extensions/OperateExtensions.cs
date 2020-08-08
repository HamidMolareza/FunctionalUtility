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
        ) => OperateWhen (predicate (), function);

        public static MethodResult OperateWhen (
            bool predicate,
            Action action) {
            if (predicate)
                action ();
            return MethodResult.Ok ();
        }

        public static MethodResult OperateWhen (
            Func<bool> predicate,
            Action action) => OperateWhen (predicate (), action);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<MethodResult<T>> function
        ) => predicate ? function () : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this MethodResult<T> @this,
            MethodResult predicate,
            Func<MethodResult<T>> operation
        ) => predicate.IsSuccess ? operation () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this MethodResult<T> @this,
            bool predicate,
            Func<MethodResult<T>> operation
        ) => predicate ? operation () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this MethodResult<T> @this,
            Func<MethodResult> predicate,
            Func<MethodResult<T>> operation
        ) => @this.OperateWhen (predicate ().IsSuccess, operation);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<MethodResult<T>> function
        ) => @this.OperateWhen (predicate (), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<MethodResult> function
        ) => predicate ? function ().MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<MethodResult> function
        ) => @this.OperateWhen (predicate (), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<MethodResult<T>> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<MethodResult> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, MethodResult<T>> function
        ) => predicate ? function (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, MethodResult<T>> function
        ) => @this.OperateWhen (predicate (), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, MethodResult> function
        ) => predicate ? function (@this).MapMethodResult (@this) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, MethodResult<T>> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, MethodResult> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult OperateWhen (
            Func<MethodResult> predicate,
            Func<MethodResult> function
        ) => OperateWhen (predicate ().IsSuccess, function);

        public static MethodResult OperateWhen (
            Func<MethodResult> predicate,
            Action action
        ) => OperateWhen (predicate ().IsSuccess, action);

        public static MethodResult OperateWhen (
            MethodResult predicate,
            Func<MethodResult> function
        ) => OperateWhen (predicate.IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            Func<MethodResult<T>> function
        ) => @this.OperateWhen (predicate ().IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<MethodResult<T>> function
        ) => @this.OperateWhen (predicate (@this).IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            Func<T, MethodResult<T>> function
        ) => @this.OperateWhen (predicate ().IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<T, MethodResult<T>> function
        ) => @this.OperateWhen (predicate.IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<T, MethodResult<T>> function
        ) => @this.OperateWhen (predicate (@this).IsSuccess, function);

        public static T OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T> function
        ) => predicate ? function () : @this;

        public static T OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T> function
        ) => @this.OperateWhen (predicate (), function);

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
                Action action) =>
            @this.OperateWhen (predicate (), action);

        public static T OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult<T> OperateWhen<T> (
                this T @this,
                Func<T, bool> predicate,
                Action action) =>
            @this.OperateWhen (predicate (@this), action);

        public static T OperateWhen<T> (
            this T @this,
            bool predicate,
            Func<T, T> function
        ) => predicate? function (@this): @this;

        public static T OperateWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, T> function
        ) => @this.OperateWhen (predicate (), function);

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
                Action<T> action) =>
            @this.OperateWhen (predicate (), action);

        public static T OperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, T> function
        ) => @this.OperateWhen (predicate (@this), function);

        public static MethodResult<T> OperateWhen<T> (
                this T @this,
                Func<T, bool> predicate,
                Action<T> action) =>
            @this.OperateWhen (predicate (@this), action);

        public static T OperateWhen<T> (
                this T @this,
                MethodResult predicate,
                Func<T> function) =>
            @this.OperateWhen (predicate.IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action action
        ) => @this.OperateWhen (predicate.IsSuccess, action);

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T> function) =>
            @this.OperateWhen (predicate (@this).IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) => @this.OperateWhen (predicate (@this).IsSuccess, action);

        public static T OperateWhen<T> (
                this T @this,
                MethodResult predicate,
                Func<T, T> function) =>
            @this.OperateWhen (predicate.IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) => @this.OperateWhen (predicate.IsSuccess, action);

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T, T> function) =>
            @this.OperateWhen (predicate (@this).IsSuccess, function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) => @this.OperateWhen (predicate (@this).IsSuccess, action);

        #endregion

        #region OperateWhenAsync

        public static async Task OperateWhenAsync (
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function ();
        }

        public static Task OperateWhenAsync (
                Func<bool> predicate,
                Func<Task> function) =>
            OperateWhenAsync (predicate (), function);

        public static async Task<MethodResult> OperateWhenAsync (
            bool predicate,
            Func<Task<MethodResult>> function) {
            if (predicate)
                return await function ();
            return MethodResult.Ok ();
        }

        public static Task<MethodResult> OperateWhenAsync (
                Func<bool> predicate,
                Func<Task<MethodResult>> function) =>
            OperateWhenAsync (predicate (), function);

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

        public static Task<T> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<T, Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<T, Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (), function);

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

        public static Task<T> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<T, T> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<T, MethodResult<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

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

        public static Task<T> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this Task<MethodResult<T>> @this,
                Func<bool> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this Task<T> @this,
                Func<bool> predicate,
                Func<Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (), function);

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

        public static Task<T> OperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this MethodResult<T> @this,
                Func<bool> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this MethodResult<T> @this,
                Func<bool> predicate,
                Func<Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static async Task<MethodResult<T>> OperateWhenAsync<T> (
            this Task<MethodResult<T>> @this,
            bool predicate,
            Func<Task<MethodResult<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function ();
            return t;
        }

        public static Task<T> OperateWhenAsync<T> (
                this T @this,
                Func<T, bool> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (@this), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this T @this,
                Func<T, bool> predicate,
                Func<Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (@this), function);

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

        public static Task<T> OperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<T, Task<T>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<T, Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (), function);

        public static Task<T> OperateWhenAsync<T> (
                this T @this,
                Func<T, bool> predicate,
                Func<T, Task<T>> function) =>
            @this.OperateWhenAsync (predicate (@this), function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this T @this,
                Func<T, bool> predicate,
                Func<T, Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (@this), function);

        public static Task<T> OperateWhenAsync<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<Task<T>> function) =>
            @this.OperateWhenAsync (predicate (@this).IsSuccess, function);

        public static Task<MethodResult<T>> OperateWhenAsync<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<Task<MethodResult<T>>> function) =>
            @this.OperateWhenAsync (predicate (@this).IsSuccess, function);

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
        ) => @this.TeeOperateWhen (predicate.IsSuccess, function);

        public static T TeeOperateWhen<T> (
            this T @this,
            bool predicate,
            Action action
        ) => predicate ? @this.Tee (action) : @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action action
        ) => @this.TeeOperateWhen (predicate (@this), action);

        public static T TeeOperateWhen<T> (
            this T @this,
            bool predicate,
            Action<T> action
        ) => predicate? @this.Tee (action): @this;

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Action<T> action
        ) => @this.TeeOperateWhen (predicate (@this), action);

        public static T TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action action
        ) => @this.TeeOperateWhen (predicate.IsSuccess, action);

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) => @this.TeeOperateWhen (predicate (@this).IsSuccess, action);

        public static T TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) => @this.TeeOperateWhen (predicate.IsSuccess, action);

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) => @this.TeeOperateWhen (predicate (@this).IsSuccess, action);

        #endregion

        #region TeeOperateWhenAsync

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

        public static Task<T> TeeOperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<Task> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        public static Task<MethodResult<T>> TeeOperateWhenAsync<T> (
                this MethodResult<T> @this,
                Func<bool> predicate,
                Func<Task> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        public static Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
                this TSource @this,
                Func<bool> predicate,
                Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        public static Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<bool> predicate,
                Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        public static Task<T> TeeOperateWhenAsync<T> (
                this T @this,
                Func<T, bool> predicate,
                Func<Task> function) =>
            @this.TeeOperateWhenAsync (predicate (@this), function);

        public static Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
                this TSource @this,
                Func<TSource, bool> predicate,
                Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync (predicate (@this), function);

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task> function) {
            if (predicate)
                await function (@this);
            return @this;
        }

        public static Task<T> TeeOperateWhenAsync<T> (
                this T @this,
                Func<bool> predicate,
                Func<T, Task> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        public static async Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
            this TSource @this,
            bool predicate,
            Func<TSource, Task<TResult>> function) {
            if (predicate)
                await function (@this);
            return MethodResult<TSource>.Ok (@this);
        }

        public static Task<MethodResult<TSource>> TeeOperateWhenAsync<TSource, TResult> (
                this TSource @this,
                Func<bool> predicate,
                Func<TSource, Task<TResult>> function) =>
            @this.TeeOperateWhenAsync (predicate (), function);

        #endregion

    }
}