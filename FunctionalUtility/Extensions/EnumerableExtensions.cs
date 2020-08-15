using System.Collections;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultDetails.Errors;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class EnumerableExtensions {

        public static bool IsNullOrEmpty (
                this IEnumerable? @this) =>
            @this is null || !@this.GetEnumerator ().MoveNext ();

        public static MethodResult IsNotNullOrEmpty (
            this IEnumerable? @this,
            ErrorDetail? errorDetail = null,
            bool showDefaultMessageToUser = true) {
            var error = errorDetail ?? new ErrorDetail (StatusCodes.Status400BadRequest,
                title: "IsNullOrEmptyError",
                message: "object is not null or empty.",
                showDefaultMessageToUser : showDefaultMessageToUser);
            if (@this is null || @this.IsNullOrEmpty ())
                return MethodResult.Fail (error);
            return MethodResult.Ok ();
        }
    }
}