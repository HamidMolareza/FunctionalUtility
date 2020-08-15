using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class UnauthorizedError : ErrorDetail {
        public UnauthorizedError (string? title = null, string? message = null, Exception? exception = null,
                bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status401Unauthorized, title ?? nameof (UnauthorizedError),
                message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}