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

        public static TSource Map<TSource> (
            this TSource @this,
            Action action) {
            action ();
            return @this;
        }

        public static TSource Map<TSource> (
            this TSource @this,
            Action<TSource> action) {
            action (@this);
            return @this;
        }

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

        public static MethodResult<TResult> MapMethodResult<TSource, TResult>(
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess ? MethodResult<TResult>.Ok(onSuccessFunction(@this.Value)) : onFailFunction(@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess?
        onSuccessFunction (@this.Value) : MethodResult<TResult>.Fail(onFailFunction (@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult>(
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction(@this.Value))
            : MethodResult<TResult>.Fail(onFailFunction(@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : onFailFunction(@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess
            ? onSuccessFunction()
            : MethodResult<TResult>.Fail(onFailFunction(@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : MethodResult<TResult>.Fail(onFailFunction(@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction(@this.Value))
            : onFailFunction();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            ErrorDetail errorDetail
        ) => @this.IsSuccess
            ? onSuccessFunction(@this.Value)
            : MethodResult<TResult>.Fail(errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            ErrorDetail errorDetail
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction(@this.Value))
            : MethodResult<TResult>.Fail(errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : onFailFunction();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            ErrorDetail errorDetail
        ) => @this.IsSuccess
            ? onSuccessFunction()
            : MethodResult<TResult>.Fail(errorDetail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccessFunction,
            ErrorDetail errorDetail
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : MethodResult<TResult>.Fail(errorDetail);

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
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : onFailFunction(@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess
            ? onSuccessFunction()
            : MethodResult<TResult>.Fail(onFailFunction(@this.Detail));

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, ErrorDetail> onFailFunction
        ) => @this.IsSuccess
            ? MethodResult<TResult>.Ok(onSuccessFunction())
            : MethodResult<TResult>.Fail(onFailFunction(@this.Detail));

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
            this TSource @this,
            Func<TSource, TResult> function) => @this.Try (function);

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
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            var result = onSuccessFunction ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            var result = onSuccessFunction (source);
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccessFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            var result = onSuccessFunction (source);
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            onSuccessFunction (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction,
            Func<MethodResult> onFailFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            onSuccessFunction (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }

            onSuccessFunction (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            var result = onSuccessFunction ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            var result = onSuccessFunction ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            var result = onSuccessFunction ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccessFunction,
            Func<MethodResult> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }

            onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction (source);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            return onSuccessFunction (source);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccessFunction
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction (source);
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Func<MethodResult> onSuccessFunction,
            Func<ResultDetail, MethodResult> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<ResultDetail, MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFailFunction (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction,
            Func<MethodResult<TResult>> onFailFunction
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFailFunction ();
            }

            return onSuccessFunction ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return onSuccessFunction ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Func<MethodResult> onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
            onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Func<Task<MethodResult>> onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
            await onSuccessFunction ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<Task<MethodResult<TResult>>> onSuccessFunction
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return await onSuccessFunction ();
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
        
        #region TryMapOnSuccess

        public static MethodResult TryMapOnSuccess (
            this MethodResult @this,
            Action action
        ) => @this.OnSuccess (() => TryExtensions.Try (action));

        public static MethodResult TryMapOnSuccess<T> (
            this MethodResult<T> @this,
            Action action
        ) => @this.OnSuccess (() => TryExtensions.Try (action));

        public static MethodResult TryMapOnSuccess<T> (
            this MethodResult<T> @this,
            Action<T> action
        ) => @this.OnSuccess (source => source.Try (action));

        public static MethodResult<TResult> TryMapOnSuccess<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> function
        ) => @this.OnSuccess (() => TryExtensions.Try (function));

        public static MethodResult<TResult> TryMapOnSuccess<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> function
        ) => @this.OnSuccess (source => source.Try (function));

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