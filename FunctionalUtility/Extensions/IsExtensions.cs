using FunctionalUtility.ResultDetails.Errors;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class IsExtensions {

        #region ResultDetail

        public static bool IsCode (this ResultDetail @this, int code) =>
            @this.StatusCode == code;

        public static bool IsBadRequestError (this ResultDetail @this) =>
            @this is BadRequestError || @this.StatusCode == StatusCodes.Status400BadRequest;

        public static bool IsConflictError (this ResultDetail @this) =>
            @this is ConflictError || @this.StatusCode == StatusCodes.Status409Conflict;

        public static bool IsInternalError (this ResultDetail @this) =>
            @this is InternalError || @this.StatusCode == StatusCodes.Status500InternalServerError;

        public static bool IsForbiddenError (this ResultDetail @this) =>
            @this is ForbiddenError || @this.StatusCode == StatusCodes.Status403Forbidden;

        public static bool IsNotFoundError (this ResultDetail @this) =>
            @this is NotFoundError || @this.StatusCode == StatusCodes.Status404NotFound;

        public static bool IsNotImplementedError (this ResultDetail @this) =>
            @this is NotImplementedError || @this.StatusCode == StatusCodes.Status501NotImplemented;

        public static bool IsUnauthorizedError (this ResultDetail @this) =>
            @this is UnauthorizedError || @this.StatusCode == StatusCodes.Status401Unauthorized;

        #endregion

        #region MethodResult

        public static bool IsCode (this MethodResult @this, int code) =>
            @this.Detail.IsCode (code);

        public static bool IsBadRequestError (this MethodResult @this) =>
            @this.Detail.IsBadRequestError ();

        public static bool IsConflictError (this MethodResult @this) =>
            @this.Detail.IsConflictError ();

        public static bool IsInternalError (this MethodResult @this) =>
            @this.Detail.IsInternalError ();

        public static bool IsForbiddenError (this MethodResult @this) =>
            @this.Detail.IsForbiddenError ();

        public static bool IsNotFoundError (this MethodResult @this) =>
            @this.Detail.IsNotFoundError ();

        public static bool IsNotImplementedError (this MethodResult @this) =>
            @this.Detail.IsNotImplementedError ();

        public static bool IsUnauthorizedError (this MethodResult @this) =>
            @this.Detail.IsUnauthorizedError ();

        #endregion

        #region MethodResult<T>

        public static bool IsCode<T> (this MethodResult<T> @this, int code) =>
            @this.Detail.IsCode (code);

        public static bool IsBadRequestError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsBadRequestError ();

        public static bool IsConflictError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsConflictError ();

        public static bool IsInternalError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsInternalError ();

        public static bool IsForbiddenError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsForbiddenError ();

        public static bool IsNotFoundError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsNotFoundError ();

        public static bool IsNotImplementedError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsNotImplementedError ();

        public static bool IsUnauthorizedError<T> (this MethodResult<T> @this) =>
            @this.Detail.IsUnauthorizedError ();

        #endregion

    }
}