using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails {
    public class InternalError : ErrorDetail {
        public InternalError (string? title = null, string? message = null,
            Exception? exception = null, bool showDefaultMessageToUser = true,
            object? moreDetails = null) : base (StatusCodes.Status500InternalServerError,
            title ?? nameof (InternalError), message, exception, showDefaultMessageToUser, moreDetails) { }
    }
}