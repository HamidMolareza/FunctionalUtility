using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class TryExtensions {

        #region Try

        public static MethodResult<TResult> Try<TResult> (
            Func<TResult> function) {
            try {
                return MethodResult<TResult>.Ok (function ());
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        public static MethodResult<TResult> Try<TSource, TResult> (
            this TSource @this,
            Func<TSource, TResult> function) {
            try {
                return MethodResult<TResult>.Ok (function (@this));
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        public static MethodResult<TResult> Try<TResult> (
            Func<MethodResult<TResult>> function) {
            try {
                return function ();
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        public static MethodResult<TResult> Try<TSource, TResult> (
            this TSource @this,
            Func<TSource, MethodResult<TResult>> function) {
            try {
                return function (@this);
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        public static MethodResult Try (Action action) {
            try {
                action ();
                return MethodResult.Ok ();
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        public static MethodResult Try<T> (
            this T @this,
            Action<T> action) {
            try {
                action (@this);
                return MethodResult.Ok ();
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, message : e.Message));
            }
        }

        #endregion

        #region TryAsync

        public static async Task<MethodResult<T>> TryAsync<T> (
            Func<Task<T>> function,
            int numOfTry) {
            var counter = 0;
            while (true) {

                try {
                    return MethodResult<T>.Ok (await function ());
                } catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return MethodResult<T>.Fail (new ExceptionError (e));
                }

            }
        }

        public static async Task<MethodResult<T>> TryAsync<T> (
            Func<Task<MethodResult<T>>> function,
            int numOfTry) {
            var counter = 0;
            while (true) {

                try {
                    return await function ();
                } catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return MethodResult<T>.Fail (new ExceptionError (e));
                }

            }
        }

        public static async Task<MethodResult> TryAsync (
            Func<Task> function,
            int numOfTry) {
            var counter = 0;
            while (true) {

                try {
                    await function ();
                    return MethodResult.Ok ();
                } catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return MethodResult.Fail (new ExceptionError (e));
                }

            }
        }

        public static async Task<MethodResult> TryAsync (
            Func<Task<MethodResult>> function,
            int numOfTry
        ) {
            var counter = 0;
            while (true) {

                try {
                    return await function ();
                } catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return MethodResult.Fail (new ExceptionError (e));
                }

            }
        }

        public static Task<MethodResult<TResult>> TryAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<TResult>> function,
            int numOfTry
        ) => TryAsync (() => function (@this), numOfTry);

        public static async Task<MethodResult<TResult>> TryAsync<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> function,
            int numOfTry
        )
        {
            var t = await @this;
          return await TryAsync(() => function(t), numOfTry);
        }

        public static Task<MethodResult<TResult>> TryAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<MethodResult<TResult>>> function,
            int numOfTry
        ) => TryAsync (() => function (@this), numOfTry);

        public static async Task<MethodResult<TResult>> TryAsync<TSource, TResult>(
            this Task<TSource> @this,
            Func<TSource, Task<MethodResult<TResult>>> function,
            int numOfTry
        )
        {
            var t = await @this;
            return await TryAsync(() => function(t), numOfTry);
        }

        public static Task<MethodResult> TryAsync<TSource> (
            this TSource @this,
            Func<TSource, Task> function,
            int numOfTry
        ) => TryAsync (() => function (@this), numOfTry);
        
        public static async Task<MethodResult> TryAsync<TSource> (
            this Task<TSource> @this,
            Func<TSource, Task> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryAsync(() => function(t), numOfTry);
        }

        public static Task<MethodResult> TryAsync<TSource> (
            this TSource @this,
            Func<TSource, Task<MethodResult>> function,
            int numOfTry
        ) => TryAsync (() => function (@this), numOfTry);
        
        public static async Task<MethodResult> TryAsync<TSource> (
            this Task<TSource> @this,
            Func<TSource, Task<MethodResult>> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryAsync(() => function(t), numOfTry);
        }

        #endregion

    }
}