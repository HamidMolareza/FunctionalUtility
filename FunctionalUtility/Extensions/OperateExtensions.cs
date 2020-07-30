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
            MethodResult predicate,
            Func<MethodResult> function
        ) => predicate.OnSuccess (function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<MethodResult> function
        ) => predicate.OnSuccess (function).MapMethodResult (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<MethodResult<T>> function
        ) => predicate (@this).OnSuccess (function);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<MethodResult> function
        ) => predicate (@this).OnSuccess (function).MapMethodResult (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<T, MethodResult<T>> function
        ) => predicate.OnSuccess (() => function (@this));

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<T, MethodResult> function
        ) => predicate.OnSuccess (() => function (@this)).MapMethodResult (@this);

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<T, MethodResult<T>> function
        ) => predicate (@this).OnSuccess (() => function (@this));

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<T, MethodResult> function
        ) => predicate (@this).OnSuccess (() => function (@this)).MapMethodResult (@this);

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
        ) => predicate.OnSuccess (action).MapMethodResult (@this);

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T> function) =>
            predicate (@this).IsSuccess ? function () : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) => predicate (@this).OnSuccess (action).MapMethodResult (@this);

        public static T OperateWhen<T> (
                this T @this,
                MethodResult predicate,
                Func<T, T> function) =>
            predicate.IsSuccess ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) => predicate.OnSuccess (() => action (@this)).MapMethodResult (@this);

        public static T OperateWhen<T> (
                this T @this,
                Func<T, MethodResult> predicate,
                Func<T, T> function) =>
            predicate (@this).IsSuccess ? function (@this) : @this;

        public static MethodResult<T> OperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) => predicate (@this).OnSuccess (() => action (@this)).MapMethodResult (@this);

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

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<Task<T>> function) {
            if (predicate)
                return await function ();
            return await @this;
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

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate ())
                return await function (t);
            return t;
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

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            bool predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate ? function (t) : t;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate () ? function (t) : t;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate (t) ? function (t) : t;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this Task<T> @this,
            Func<bool> predicate,
            Func<Task<T>> function) {
            if (predicate ())
                return await function ();
            return await @this;
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

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task<T>> function) {
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

        public static async Task<T> TeeOperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task> function) {
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

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function ();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<Task> function) {
            if (predicate ())
                await function ();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<Task<T>> function) {
            if (predicate (@this))
                return await function ();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<Task> function) {
            if (predicate (@this))
                await function ();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task<T>> function) {
            if (predicate)
                return await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) {
            if (predicate ())
                return await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            bool predicate,
            Func<T, Task> function) {
            if (predicate)
                await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, Task> function) {
            if (predicate ())
                await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> function) {
            if (predicate (@this))
                return await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task> function) {
            if (predicate (@this))
                await function (@this);
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<Task<T>> function) {
            if (predicate (@this).IsSuccess)
                return await function ();
            return @this;
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
        ) => predicate.OnSuccess (function).MapMethodResult (
            onSuccessFunction: () => MethodResult<T>.Ok (@this),
            onFailFunction : MethodResult<T>.Fail
        );

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
        ) => predicate.OnSuccess (action).Map (@this);

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action action
        ) => predicate (@this).OnSuccess (action).Map (@this);

        public static T TeeOperateWhen<T> (
            this T @this,
            MethodResult predicate,
            Action<T> action
        ) => predicate.OnSuccess (() => action (@this)).Map (@this);

        public static T TeeOperateWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Action<T> action
        ) => predicate (@this).OnSuccess (() => action (@this)).Map (@this);

        #endregion

    }
}