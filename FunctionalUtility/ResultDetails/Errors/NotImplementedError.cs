using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class NotImplementedError : ErrorDetail {
        public NotImplementedError (string? title = null, string? message = null,
                Exception? exception = null, bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status501NotImplemented, title ?? nameof (NotImplementedError),
                message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}