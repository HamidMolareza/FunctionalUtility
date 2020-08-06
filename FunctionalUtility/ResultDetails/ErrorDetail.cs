using System;
using System.Collections.Generic;
using System.Diagnostics;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.ResultDetails {
    public class ErrorDetail : ResultDetail {
        public ErrorDetail (int statusCode, string? title = null,
            string? message = null, Exception? exception = null,
            bool showDefaultMessageToUser = true, object? moreDetail = null) : base (
            statusCode, title?? "Error", message ?? "No Data.", moreDetail : moreDetail) {
            Exception = exception;
            ShowDefaultMessageToUser = showDefaultMessageToUser;
        }

        protected bool ShowDefaultMessageToUser { get; }
        public StackTrace StackTrace { get; } = new StackTrace (1, true);
        public Exception? Exception { get; }

        public override object GetViewModel () =>
            ShowDefaultMessageToUser ?
            new { StatusCode, Title = "Error!", Message = "something went wrong." } :
            new { StatusCode, Title, Message };
    }
}