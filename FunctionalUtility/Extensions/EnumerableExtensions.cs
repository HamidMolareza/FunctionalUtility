using System.Collections;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class EnumerableExtensions {

        public static bool IsNullOrEmpty (
                this IEnumerable? @this) =>
            @this is null || !@this.GetEnumerator ().MoveNext ();

        public static MethodResult IsNotNullOrEmpty (
                this IEnumerable? @this,
                ErrorDetail? errorDetail = null) =>
            @this.FailWhen (result => result.IsNullOrEmpty (),
                errorDetail ?? new ErrorDetail (StatusCodes.Status400BadRequest,
                    message: "object is not null or empty."))
            .MapMethodResult ();

    }
}