using System.Text.RegularExpressions;
using FunctionalUtility.ResultDetails.Errors;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.Extensions {
    public static class StringExtensions {

        public static MethodResult<string> MustMatchRegex (
                this string @this, Regex rgx,
                ErrorDetail? errorDetail = null,
                bool showDefaultMessageToUser = true) =>
            @this.FailWhen (!rgx.IsMatch (@this),
                errorDetail ??
                new ErrorDetail (StatusCodes.Status400BadRequest,
                    message: $"({@this}) is not match with {rgx}",
                    showDefaultMessageToUser : showDefaultMessageToUser));
    }
}