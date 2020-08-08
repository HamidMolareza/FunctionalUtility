using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {
    public static class MapExtensions {

        #region Map

        public static TResult Map<TSource, TResult> (
            this TSource @this,
            Func<TSource, TResult> function) => function (@this);

        public static TResult Map<TSource, TResult> (
            this TSource _,
            Func<TResult> function) => function ();

        public static TResult Map<TSource, TResult> (
            this TSource _,
            TResult result) => result;

        #endregion

        #region MapMethodResult

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<ResultDetail, TResult> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : onFailFunction (@this.Detail);

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, TResult> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : onFailFunction (@this.Detail);

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<TResult> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : onFailFunction ();

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<TResult> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : onFailFunction ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : onFailFunction ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : onFailFunction ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess ? MethodResult<TResult>.Ok (onSuccessFunction (@this.Value)) : onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> onSuccessFunction,
                Func<ResultDetail, ErrorDetail> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction (@this.Value)) :
            MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                Func<ResultDetail, ErrorDetail> onFailFunction
            ) => @this.IsSuccess ?
            onSuccessFunction () :
            MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, ErrorDetail> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction (@this.Value)) :
            onFailFunction ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, MethodResult<TResult>> onSuccessFunction,
                ErrorDetail errorDetail
            ) => @this.IsSuccess ?
            onSuccessFunction (@this.Value) :
            MethodResult<TResult>.Fail (errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TSource, TResult> onSuccessFunction,
                ErrorDetail errorDetail
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction (@this.Value)) :
            MethodResult<TResult>.Fail (errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            onFailFunction ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                ErrorDetail errorDetail
            ) => @this.IsSuccess ?
            onSuccessFunction () :
            MethodResult<TResult>.Fail (errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                Func<TResult> onSuccessFunction,
                ErrorDetail errorDetail
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            MethodResult<TResult>.Fail (errorDetail);

        public static TResult MapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, TResult> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess ? onSuccessFunction () : onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccessFunction
        ) => @this.IsSuccess?
        onSuccessFunction () : MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
                this MethodResult @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            onFailFunction (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
                this MethodResult @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                Func<ResultDetail, ErrorDetail> onFailFunction
            ) => @this.IsSuccess ?
            onSuccessFunction () :
            MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TResult> (
                this MethodResult @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, ErrorDetail> onFailFunction
            ) => @this.IsSuccess ?
            MethodResult<TResult>.Ok (onSuccessFunction ()) :
            MethodResult<TResult>.Fail (onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                TResult value) => @this
            .OnSuccess (value)
            .OnFail (methodResult => MethodResult<TResult>.Fail (methodResult.Detail));

        public static MethodResult<TResult> MapMethodResult<TResult> (
                this MethodResult @this,
                TResult value) => @this
            .OnSuccess (value)
            .OnFail (methodResult => MethodResult<TResult>.Fail (methodResult.Detail));

        public static MethodResult MapMethodResult<TSource> (
                this MethodResult<TSource> @this) =>
            @this.IsSuccess ? MethodResult.Ok () : MethodResult.Fail (@this.Detail);

        #endregion

        #region TryMap

        public static MethodResult<TResult> TryMap<TSource, TResult> (
            this TSource _,
            Func<MethodResult<TResult>> onSuccessFunction
        ) => TryExtensions.Try (onSuccessFunction);

        public static MethodResult<TResult> TryMap<TSource, TResult> (
            this TSource _,
            Func<TResult> onSuccessFunction
        ) => TryExtensions.Try (onSuccessFunction);

        public static MethodResult<TResult> TryMap<TSource, TResult> (
            this TSource @this,
            Func<TSource, TResult> function) => TryExtensions.Try (() => function (@this));

        public static MethodResult<TResult> TryMap<TSource, TResult> (
                this TSource @this,
                Func<TSource, MethodResult<TResult>> function) =>
            TryExtensions.Try (() => function (@this));

        #endregion

        #region TryMapMethodResult

        public static MethodResult<TResult> TryMapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<ResultDetail, TResult> onFailFunction
        ) => TryExtensions.Try (() => @this.MapMethodResult (onSuccessFunction, onFailFunction));

        public static MethodResult<TResult> TryMapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, TResult> onFailFunction
        ) => TryExtensions.Try (() => @this.MapMethodResult (onSuccessFunction, onFailFunction));

        #endregion

        #region TryMapAsync

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
                var result = onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e,
                    moreDetails : new { thisObj = @this }));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {

                var source = await @this;
                var result = onSuccessFunction (source);
                return MethodResult<TResult>.Ok (result);

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccessFunction
        ) {
            try {

                var source = await @this;
                var result = onSuccessFunction (source);
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, Task<MethodResult<TResult>>> onSuccessFunction
        ) {
            try {
                var source = await @this;
                return await onSuccessFunction (source);
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<MethodResult<TResult>>> onSuccessFunction
        ) => TryExtensions.TryAsync (() => onSuccessFunction (@this));

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> onSuccessFunction
        ) {
            try {

                var source = await @this;
                var result = await onSuccessFunction (source);
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<TResult>> onSuccessFunction
        ) => TryExtensions.TryAsync (() => onSuccessFunction (@this));

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {

                var source = await @this;
                onSuccessFunction (source);
                return MethodResult.Ok ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {

                await @this;
                onSuccessFunction ();
                return MethodResult.Ok ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction,
            Func<MethodResult> onFailFunction
        ) {
            try {

                var source = await @this;
                onSuccessFunction (source);
                return MethodResult.Ok ();

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {

                await @this;
                var result = onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {

                await @this;
                var result = onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction
        ) {
            try {

                await @this;
                var result = onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<Task<TResult>> onSuccessFunction
        ) {
            try {

                await @this;
                var result = await onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource _,
            Func<Task<TResult>> onSuccessFunction
        ) {
            try {

                var result = await onSuccessFunction ();
                return MethodResult<TResult>.Ok (result);

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<Task<MethodResult<TResult>>> onSuccessFunction
        ) {
            try {

                await @this;
                return await onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource _,
            Func<Task<MethodResult<TResult>>> onSuccessFunction
        ) {
            try {

                return await onSuccessFunction ();

            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {

                await @this;
                onSuccessFunction ();
                return MethodResult.Ok ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccessFunction,
            Func<MethodResult> onFailFunction
        ) {
            try {

                await @this;
                onSuccessFunction ();
                return MethodResult.Ok ();

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {

                var source = await @this;
                return onSuccessFunction (source);

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {

                var source = await @this;
                return onSuccessFunction (source);

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Func<MethodResult> onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {

                await @this;
                return onSuccessFunction ();

            } catch (Exception) {
                return onFailFunction ();
            }
        }

        public static Task<MethodResult> TryMapAsync<TSource> (
            this TSource _,
            Func<Task<MethodResult>> onSuccessFunction
        ) => TryExtensions.TryAsync (onSuccessFunction);

        public static Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<TResult>> function,
            int numOfTry
        ) => TryExtensions.TryAsync (() => function (@this), numOfTry);

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, Task<TResult>> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryExtensions.TryAsync (() => function (t), numOfTry);
        }

        public static Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this TSource @this,
            Func<TSource, Task<MethodResult<TResult>>> function,
            int numOfTry
        ) => TryExtensions.TryAsync (() => function (@this), numOfTry);

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, Task<MethodResult<TResult>>> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryExtensions.TryAsync (() => function (t), numOfTry);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> function
        ) {
            var t = await @this;
            return TryExtensions.Try (() => function (t));
        }

        #endregion

        #region TryMapMethodResultAsync

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (onFailFunction);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccessFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction);

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccessFunction,
                Func<ResultDetail, MethodResult> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action onSuccessFunction,
                Func<ResultDetail, MethodResult> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccessFunction,
                Func<MethodResult> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (onFailFunction);

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccessFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (onFailFunction);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccessFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction);

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccessFunction,
                Func<ResultDetail, MethodResult> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccessFunction,
                Func<MethodResult> onFailFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction)
            .TryOnFail (onFailFunction);

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccessFunction
            ) => (await @this)
            .TryOnSuccess (onSuccessFunction);

        #endregion

        #region MapMethodResultAsync

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (onFailFunction);

        public static async Task<MethodResult> MapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult> onSuccessFunction,
                Func<MethodResult> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (onFailFunction);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccessFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction);

        public static async Task<MethodResult> MapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult> onSuccessFunction,
                Func<ResultDetail, MethodResult> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                Func<ResultDetail, MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (detail => onFailFunction (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccessFunction,
                Func<MethodResult<TResult>> onFailFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction)
            .OnFail (onFailFunction);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccessFunction
            ) => (await @this)
            .OnSuccess (onSuccessFunction);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
            this Task<MethodResult> @this,
            TResult result
        ) => (await @this).MapMethodResult (result);

        public static async Task<MethodResult> MapMethodResultAsync<TSource> (
            this Task<MethodResult<TSource>> @this) {
            var methodResult = await @this;
            return methodResult.IsSuccess ? MethodResult.Ok () : MethodResult.Fail (methodResult.Detail);
        }

        #endregion

        #region GetValue

        public static T GetValue<T> (this MethodResult<T> @this) => @this.Value;

        #endregion

        #region MapToTask

        public static Task<T> MapToTask<T> (
            this T @this) => Task.FromResult (@this);

        #endregion

    }
}