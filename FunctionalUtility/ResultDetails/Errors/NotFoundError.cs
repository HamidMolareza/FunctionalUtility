using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class NotFoundError : ErrorDetail {
        public NotFoundError (string? title = null, string? message = null, Exception? exception = null,
                bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status404NotFound, title ?? nameof (NotFoundError), message,
                exception, showDefaultMessageToUser, moreDetails) { }
    }
}