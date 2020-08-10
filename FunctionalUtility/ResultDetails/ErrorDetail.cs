using System;
using System.Diagnostics;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.ResultDetails {
    public class ErrorDetail : ResultDetail {
        public ErrorDetail (int statusCode, string? title = null,
            string? message = null, Exception? exception = null,
            bool showDefaultMessageToUser = true, object? moreDetails = null) : base (
            statusCode, title?? "Error", message ?? "No Data.", moreDetails : moreDetails) {
            ShowDefaultMessageToUser = showDefaultMessageToUser;
            if (exception != null)
                Exception = new ExceptionData (exception);
        }

        protected bool ShowDefaultMessageToUser { get; }

        public StackTrace StackTrace { get; } = new StackTrace (1, true);
        public ExceptionData? Exception { get; }

        public override object GetViewModel () =>
            ShowDefaultMessageToUser ?
            new { StatusCode, Title = "Error!", Message = "something went wrong." } :
            new { StatusCode, Title, Message };
    }
}