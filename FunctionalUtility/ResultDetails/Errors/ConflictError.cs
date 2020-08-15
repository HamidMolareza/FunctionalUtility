using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class ConflictError : ErrorDetail {
        public ConflictError (string? title = null, string? message = null, Exception? exception = null,
                bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status409Conflict, title ?? nameof (ConflictError),
                message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}