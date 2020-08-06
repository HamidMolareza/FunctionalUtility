using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails {
    public class ExceptionError : ErrorDetail {
        public ExceptionError (Exception exception, string? title = null,
                string? message = null, object? detail = null):
            base (StatusCodes.Status500InternalServerError, title ?? nameof (ExceptionError),
                message?? "An exception has occurred.", exception : exception, detail : detail) { }
    }
}