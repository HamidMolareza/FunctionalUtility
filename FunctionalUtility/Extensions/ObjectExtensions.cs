using System;
using System.Collections.Generic;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultDetails.Errors;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class ObjectExtensions {
        public static MethodResult<T> IsNotNull<T> (
                this object? @this,
                ErrorDetail? errorDetail = null,
                bool showDefaultMessageToUser = true) =>
            @this.FailWhen (@this is null, errorDetail ?? new ErrorDetail (
                StatusCodes.Status400BadRequest, title: "NullError",
                message: "Object is null.", showDefaultMessageToUser : showDefaultMessageToUser))
            .MapMethodResult ((T) @this!);

        public static MethodResult<TResult> As<TResult> (
                this object @this,
                ErrorDetail? errorDetail = null,
                bool showDefaultMessageToUser = true) =>
            TryExtensions.Try (() => Convert.ChangeType (@this, typeof (TResult)))
            .OnSuccess (obj => obj.IsNotNull<TResult> ())
            .OnFail (() =>
                MethodResult<TResult>.Fail (errorDetail ??
                    new ErrorDetail (StatusCodes.Status400BadRequest,
                        message: $"({@this} - Type of ({@this.GetType()})) is not {typeof(TResult)}",
                        showDefaultMessageToUser : showDefaultMessageToUser)));

        public static MethodResult AreNull (
                this IEnumerable<object?> @this,
                bool showDefaultMessageToUser = true) =>
            @this.ForEachUntilIsSuccess (obj =>
                FailExtensions.FailWhen (obj != null, new ErrorDetail (
                    StatusCodes.Status400BadRequest, message: $"{obj} is not null.",
                    showDefaultMessageToUser : showDefaultMessageToUser))
            );
    }
}