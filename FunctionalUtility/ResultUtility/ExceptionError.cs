using System;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultUtility
{
    public class ExceptionError : ErrorDetail {
        public ExceptionError (Exception exception, string? title = null, string? message = null):
            base (StatusCodes.Status500InternalServerError, title ?? nameof (ExceptionError), "An exception has occurred.", exception : exception) { }
    }
}