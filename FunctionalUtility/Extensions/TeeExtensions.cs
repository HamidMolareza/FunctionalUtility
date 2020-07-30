using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class TeeExtensions {

        #region Tee

        public static T Tee<T> (
            this T @this,
            Action<T> action) {
            action (@this);
            return @this;
        }

        public static T Tee<T> (
            this T @this,
            Action ? action) {
            action?.Invoke ();
            return @this;
        }

        public static TSource Tee<TSource, TResult> (
            this TSource @this,
            Func<TSource, TResult> function) {
            function (@this);
            return @this;
        }

        public static TSource Tee<TSource, TResult> (
            this TSource @this,
            Func<TResult> function) {
            function ();
            return @this;
        }

        #endregion

        #region TryTee

        public static MethodResult<T> TryTee<T> (
            this T @this,
            Action<T> action) => TryExtensions.Try (() => @this.Tee (action));

        public static MethodResult<T> TryTee<T> (
            this T @this,
            Action? action) => TryExtensions.Try (() => @this.Tee (action));

        #endregion

        #region TeeOnSuccess

        public static MethodResult<T> TeeOnSuccess<T>(
            this MethodResult<T> @this,
            Action<T> action)
        {
            if (@this.IsSuccess)
                action(@this.Value);
            return @this;
        }

        public static MethodResult<T> TeeOnSuccess<T> (
                this MethodResult<T> @this,
                Action action) => @this
            .OnSuccess (() => @this.Tee (action));

        public static MethodResult TeeOnSuccess(
            this MethodResult @this,
            Action action) =>
            @this.OnSuccess(() => @this.Tee(action));

        public static MethodResult<TSource> TeeOnSuccess<TSource, TResult>(
            this MethodResult<TSource> @this,
            Func<TSource, TResult> function)
        {
            if (@this.IsSuccess)
                function(@this.Value);
            return @this;
        }

        public static MethodResult<TSource> TeeOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> function) => @this
            .OnSuccess (() => @this.Tee (function));

        public static MethodResult TeeOnSuccess<TResult>(
            this MethodResult @this,
            Func<TResult> function) =>
            @this.OnSuccess(() => @this.Tee(function));

        #endregion

        #region TeeOnSuccessAsync

        public static async Task<MethodResult<T>> TeeOnSuccessAsync<T> (
                this Task<MethodResult<T>> @this,
                Action<T> action)
        {
            var t = await @this;
            if (t.IsSuccess)
                action(t.Value);
            return t;
        }

        public static Task<MethodResult<T>> TeeOnSuccessAsync<T> (
                this Task<MethodResult<T>> @this,
                Action action) => @this
            .OnSuccessAsync (() => @this.Tee (action));

        public static Task<MethodResult> TeeOnSuccessAsync(
            this Task<MethodResult> @this,
            Action action) =>
            @this.OnSuccessAsync(() => @this.Tee(action));

        public static async Task<MethodResult<TSource>> TeeOnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> function) {
            var t = await @this;
            if (t.IsSuccess)
                function(t.Value);
            return t;
        }

        public static Task<MethodResult<TSource>> TeeOnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TResult> function) => @this
            .OnSuccessAsync (() => @this.Tee (function));

        public static Task<MethodResult> TeeOnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> function) => 
            @this.OnSuccessAsync (() => @this.Tee (function));

        #endregion

        #region TryTeeOnSuccess

        public static MethodResult<T> TryTeeOnSuccess<T> (
                this MethodResult<T> @this,
                Action<T> action) => @this
            .OnSuccess (value => value.TryTee (action));

        public static MethodResult<T> TryTeeOnSuccess<T> (
                this MethodResult<T> @this,
                Action action) => @this
            .OnSuccess (value => value.TryTee (action));

        public static MethodResult TryTeeOnSuccess (
                this MethodResult @this,
                Action action) => @this
            .OnSuccess (() => TryExtensions.Try (action));

        #endregion

    }
}