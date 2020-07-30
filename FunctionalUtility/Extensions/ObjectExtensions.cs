using System;
using System.Collections.Generic;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class ObjectExtensions {
        public static MethodResult<T> IsNotNull<T> (
                this object? @this,
                ErrorDetail? errorDetail = null) =>
            @this.FailWhen (@this is null, errorDetail ?? new ErrorDetail (
                StatusCodes.Status400BadRequest, message: "Object is null."))
            .MapMethodResult ((T) @this!);

        public static MethodResult<TResult> As<TResult> (
                this object @this,
                ErrorDetail? errorDetail = null) =>
            TryExtensions.Try (() => Convert.ChangeType (@this, typeof (TResult)))
            .OnSuccess (obj => obj.IsNotNull<TResult> ())
            .OnFail (() =>
                MethodResult<TResult>.Fail (errorDetail ??
                    new ErrorDetail (StatusCodes.Status400BadRequest,
                        message: $"Object is not {typeof(TResult)}")));

        public static MethodResult AreNull (
                this IEnumerable<object?> @this) =>
            @this.ForEachUntilIsSuccess (obj =>
                FailExtensions.FailWhen (obj is null, new ErrorDetail (
                    StatusCodes.Status400BadRequest))
            );
    }
}