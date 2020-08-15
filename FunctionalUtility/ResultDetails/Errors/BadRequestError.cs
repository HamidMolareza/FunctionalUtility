using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Errors {
    public class BadRequestError : ErrorDetail {
        public BadRequestError (string? title = null, string? message = null, Exception? exception = null,
                bool showDefaultMessageToUser = true, object? moreDetails = null):
            base (StatusCodes.Status400BadRequest, title ?? nameof (BadRequestError),
                message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}