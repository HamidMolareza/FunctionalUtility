using System;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
    public static class FailExtensions {

        #region FailWhen

        public static MethodResult FailWhen (
            bool predicate,
            ErrorDetail errorDetail
        ) => predicate ? MethodResult.Fail (errorDetail) : MethodResult.Ok ();

        public static MethodResult FailWhen (
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => predicate () ? MethodResult.Fail (errorDetail) : MethodResult.Ok ();

        public static MethodResult FailWhen (
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => predicate.IsSuccess ? MethodResult.Fail (errorDetail) : MethodResult.Ok ();

        public static MethodResult FailWhen (
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => predicate ().IsSuccess ? MethodResult.Fail (errorDetail) : MethodResult.Ok ();

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            bool predicate,
            ErrorDetail errorDetail
        ) => predicate ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            bool predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            ErrorDetail errorDetail
        ) => predicate (@this) ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<T, bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate (@this) ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<bool> predicate,
            ErrorDetail errorDetail
        ) => predicate () ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<bool> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate () ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            MethodResult predicate,
            ErrorDetail errorDetail
        ) => predicate.IsSuccess ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            MethodResult predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate.IsSuccess ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            ErrorDetail errorDetail
        ) => predicate ().IsSuccess ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate ().IsSuccess ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            ErrorDetail errorDetail
        ) => predicate (@this).IsSuccess ? MethodResult<T>.Fail (errorDetail) : MethodResult<T>.Ok (@this);

        public static MethodResult<T> FailWhen<T> (
            this T @this,
            Func<T, MethodResult> predicate,
            Func<T, ErrorDetail> errorDetail
        ) => predicate (@this).IsSuccess ? MethodResult<T>.Fail (errorDetail (@this)) : MethodResult<T>.Ok (@this);

        #endregion

        #region Fail

        public static MethodResult Fail (
            this MethodResult @this,
            ErrorDetail errorDetail
        ) => MethodResult.Fail (errorDetail);

        public static MethodResult<T> Fail<T> (
            this MethodResult<T> @this,
            ErrorDetail errorDetail
        ) => MethodResult<T>.Fail (errorDetail);

        #endregion

    }
}