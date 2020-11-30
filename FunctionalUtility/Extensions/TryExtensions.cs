using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails.Errors;
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

        public static MethodResult Try (
            Func<MethodResult> function) {
            try {
                return function ();
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, message : e.Message));
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
                return MethodResult.Fail (new ExceptionError (e));
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
                        return MethodResult<T>.Fail (new ExceptionError (e,
                            moreDetails : new { numOfTry }));
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
                        return MethodResult<T>.Fail (new ExceptionError (e,
                            moreDetails : new { numOfTry }));
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
                        return MethodResult.Fail (new ExceptionError (e,
                            moreDetails : new { numOfTry }));
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
                        return MethodResult.Fail (new ExceptionError (e,
                            moreDetails : new { numOfTry }));
                }

            }
        }

        public static Task<MethodResult> TryAsync<TSource> (
            this TSource @this,
            Func<TSource, Task> function,
            int numOfTry
        ) => TryAsync (() => function (@this), numOfTry);

        public static async Task<MethodResult> TryAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction
        ) {
            try {

                var source = await @this;
                onSuccessFunction (source);
                return MethodResult.Ok ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync<TSource> (
            this Task<TSource> @this,
            Action onSuccessFunction
        ) {
            try {

                await @this;
                onSuccessFunction ();
                return MethodResult.Ok ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<T>> TryAsync<T> (
            Func<Task<T>> onSuccessFunction
        ) {
            try {

                var result = await onSuccessFunction ();
                return MethodResult<T>.Ok (result);

            } catch (Exception e) {
                return MethodResult<T>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync (
            this Task @this,
            Action onSuccessFunction
        ) {
            try {

                await @this;
                onSuccessFunction ();
                return MethodResult.Ok ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }
        public static async Task<MethodResult> TryAsync (
            Func<Task<MethodResult>> onSuccessFunction
        ) {
            try {

                return await onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync<T> (
            this T @this,
            Func<T, Task<MethodResult>> onSuccessFunction
        ) {
            try {

                return await onSuccessFunction (@this);

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync (
            this Task @this,
            Func<MethodResult> onSuccessFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync (
            this Task @this,
            Func<Task<MethodResult>> onSuccessFunction
        ) {
            try {

                await @this;
                return await onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryAsync<TResult> (
            Func<Task<MethodResult<TResult>>> onSuccessFunction
        ) {
            try {

                return await onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryAsync<TSource> (
            this Task<TSource> @this,
            Func<TSource, Task> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryAsync (() => function (t), numOfTry);
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
            return await TryAsync (() => function (t), numOfTry);
        }

        #endregion

    }
}