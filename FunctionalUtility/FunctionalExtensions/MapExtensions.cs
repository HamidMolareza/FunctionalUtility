using System;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
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
            Func<TSource, TResult> onSuccess,
            Func<ResultDetail, TResult> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : onFail (@this.Detail);

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, TResult> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail (@this.Detail);

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccess,
            Func<TResult> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : onFail ();

        public static TResult MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            Func<TResult> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : onFail ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value).Map (MethodResult<TResult>.Ok) : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value).Map (MethodResult<TResult>.Ok):
            onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok) : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok):
            onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess (@this.Value).Map (MethodResult<TResult>.Ok) : onFail ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            ErrorDetail errorDetail
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : errorDetail.Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, TResult> onSuccess,
            ErrorDetail errorDetail
        ) => @this.IsSuccess?
        onSuccess (@this.Value).Map (MethodResult<TResult>.Ok) : errorDetail.Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok) : onFail ();

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccess,
            ErrorDetail errorDetail
        ) => @this.IsSuccess?
        onSuccess () : errorDetail.Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TResult> onSuccess,
            ErrorDetail errorDetail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok) : errorDetail.Map (MethodResult<TResult>.Fail);

        public static TResult MapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, TResult> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess ? onSuccess () : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess
        ) => @this.IsSuccess?
        onSuccess (@this.Value) : MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
            this MethodResult<TSource> @this,
            Func<MethodResult<TResult>> onSuccess
        ) => @this.IsSuccess?
        onSuccess () : MethodResult<TResult>.Fail (@this.Detail);
        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccess
        ) => @this.IsSuccess?
        onSuccess () : MethodResult<TResult>.Fail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok) : onFail (@this.Detail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess () : onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, ErrorDetail> onFail
        ) => @this.IsSuccess?
        onSuccess ().Map (MethodResult<TResult>.Ok) : onFail (@this.Detail).Map (MethodResult<TResult>.Fail);

        public static MethodResult<TResult> MapMethodResult<TSource, TResult> (
                this MethodResult<TSource> @this,
                TResult value) => @this
            .OnSuccess (() => MethodResult<TResult>.Ok (value))
            .OnFail (methodResult => MethodResult<TResult>.Fail (methodResult.Detail));

        public static MethodResult<TResult> MapMethodResult<TResult> (
                this MethodResult @this,
                TResult value) => @this
            .OnSuccess (() => MethodResult<TResult>.Ok (value))
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
            Func<TSource, TResult> onSuccess,
            Func<ResultDetail, TResult> onFail
        ) => TryExtensions.Try (() => @this.MapMethodResult (onSuccess, onFail));

        public static MethodResult<TResult> TryMapMethodResult<TResult> (
            this MethodResult @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, TResult> onFail
        ) => TryExtensions.Try (() => @this.MapMethodResult (onSuccess, onFail));

        #endregion

        #region TryMapAsync

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            var result = onSuccess ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFail ();
            }

            var result = onSuccess (source);
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, TResult> onSuccess
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            var result = onSuccess (source);
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccess,
            Func<ResultDetail, MethodResult> onFail
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            onSuccess (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action onSuccess,
            Func<ResultDetail, MethodResult> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccess,
            Func<MethodResult> onFail
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFail ();
            }

            onSuccess (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Action<TSource> onSuccess
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }

            onSuccess (source);
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            var result = onSuccess ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFail ();
            }

            var result = onSuccess ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<TResult> onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            var result = onSuccess ();
            return MethodResult<TResult>.Ok (result);
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccess,
            Func<ResultDetail, MethodResult> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccess,
            Func<MethodResult> onFail
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFail ();
            }

            onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Action onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }

            onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            return onSuccess (source);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            return onSuccess ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception) {
                return onFail ();
            }

            return onSuccess (source);
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TSource, TResult> (
            this Task<TSource> @this,
            Func<TSource, MethodResult<TResult>> onSuccess
        ) {
            TSource source;
            try {
                source = await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return onSuccess (source);
        }

        public static async Task<MethodResult> TryMapAsync<TSource> (
            this Task<TSource> @this,
            Func<MethodResult> onSuccess,
            Func<ResultDetail, MethodResult> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            return onSuccess ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<ResultDetail, MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return onFail (new ExceptionError (e, e.Message));
            }

            return onSuccess ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccess,
            Func<MethodResult<TResult>> onFail
        ) {
            try {
                await @this;
            } catch (Exception) {
                return onFail ();
            }

            return onSuccess ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<MethodResult<TResult>> onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return onSuccess ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Func<MethodResult> onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
            onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> TryMapAsync (
            this Task @this,
            Func<Task<MethodResult>> onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult.Fail (new ExceptionError (e, e.Message));
            }
            await onSuccess ();
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult<TResult>> TryMapAsync<TResult> (
            this Task @this,
            Func<Task<MethodResult<TResult>>> onSuccess
        ) {
            try {
                await @this;
            } catch (Exception e) {
                return MethodResult<TResult>.Fail (new ExceptionError (e, e.Message));
            }

            return await onSuccess ();
        }

        #endregion

        #region TryMapMethodResultAsync

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TResult> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccess,
                Func<MethodResult<TResult>> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, TResult> onSuccess
            ) => (await @this)
            .TryOnSuccess (onSuccess);

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccess,
                Func<ResultDetail, MethodResult> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action onSuccess,
                Func<ResultDetail, MethodResult> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccess,
                Func<MethodResult> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult> TryMapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Action<TSource> onSuccess
            ) => (await @this)
            .TryOnSuccess (onSuccess);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccess,
                Func<MethodResult<TResult>> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult<TResult>> TryMapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<TResult> onSuccess
            ) => (await @this)
            .TryOnSuccess (onSuccess);

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccess,
                Func<ResultDetail, MethodResult> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccess,
                Func<MethodResult> onFail
            ) => (await @this)
            .TryOnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult> TryMapMethodResultAsync (
                this Task<MethodResult> @this,
                Action onSuccess
            ) => (await @this)
            .TryOnSuccess (onSuccess);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult<TResult>> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccess,
                Func<MethodResult<TResult>> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult> MapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult> onSuccess,
                Func<MethodResult> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TSource, TResult> (
                this Task<MethodResult<TSource>> @this,
                Func<TSource, MethodResult<TResult>> onSuccess
            ) => (await @this)
            .OnSuccess (onSuccess);

        public static async Task<MethodResult> MapMethodResultAsync<TSource> (
                this Task<MethodResult<TSource>> @this,
                Func<MethodResult> onSuccess,
                Func<ResultDetail, MethodResult> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccess,
                Func<ResultDetail, MethodResult<TResult>> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (detail => onFail (detail.Detail));

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccess,
                Func<MethodResult<TResult>> onFail
            ) => (await @this)
            .OnSuccess (onSuccess)
            .OnFail (onFail);

        public static async Task<MethodResult<TResult>> MapMethodResultAsync<TResult> (
                this Task<MethodResult> @this,
                Func<MethodResult<TResult>> onSuccess
            ) => (await @this)
            .OnSuccess (onSuccess);

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