using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
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

        public static MethodResult<T> TeeOnSuccess<T> (
                this MethodResult<T> @this,
                Action<T> action) => @this
            .OnSuccess (value =>
                value.Tee (action)
                .Map (_ => @this)
            );

        public static MethodResult<T> TeeOnSuccess<T> (
                this MethodResult<T> @this,
                Action action) => @this
            .OnSuccess (() => @this.Tee (action));

        public static MethodResult TeeOnSuccess (
                this MethodResult @this,
                Action action) => @this
            .OnSuccess (() =>
                @this.Tee (action));

        public static MethodResult<TSource> TeeOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> function) => @this
            .OnSuccess (value =>
                value.Tee (function)
                .Map (_ => @this)
            );

        public static MethodResult<TSource> TeeOnSuccess<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> function) => @this
            .OnSuccess (() => @this.Tee (function));

        public static MethodResult TeeOnSuccess<TResult> (
                this MethodResult @this,
                Func<TResult> function) => @this
            .OnSuccess (() =>
                @this.Tee (function));

        #endregion

        #region TeeOnSuccessAsync

        public static Task<MethodResult<T>> TeeOnSuccessAsync<T> (
                this Task<MethodResult<T>> @this,
                Action<T> action) => @this
            .OnSuccessAsync (value =>
                value.Tee (action)
                .Map (_ => @this)
            );

        public static Task<MethodResult<T>> TeeOnSuccessAsync<T> (
                this Task<MethodResult<T>> @this,
                Action action) => @this
            .OnSuccessAsync (() => @this.Tee (action));

        public static Task<MethodResult> TeeOnSuccessAsync (
                this Task<MethodResult> @this,
                Action action) => @this
            .OnSuccessAsync (() =>
                @this.Tee (action));

        public static Task<MethodResult<TSource>> TeeOnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> function) => @this
            .OnSuccessAsync (value =>
                value.Tee (function)
                .Map (_ => @this)
            );

        public static Task<MethodResult<TSource>> TeeOnSuccessAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TResult> function) => @this
            .OnSuccessAsync (() => @this.Tee (function));

        public static Task<MethodResult> TeeOnSuccessAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> function) => @this
            .OnSuccessAsync (() =>
                @this.Tee (function));

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