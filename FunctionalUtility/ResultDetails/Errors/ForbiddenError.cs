using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class ForbiddenError : ErrorDetail {
        public ForbiddenError (string? title = null, string? message = null, Exception? exception = null,
                bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status403Forbidden, title ?? nameof (ForbiddenError),
                message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}