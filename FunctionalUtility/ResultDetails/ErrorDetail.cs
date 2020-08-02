using System;
using System.Diagnostics;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.ResultDetails {
    public class ErrorDetail : ResultDetail {
        public ErrorDetail (int statusCode, string? title = null, string? message = null,
            Exception? exception = null) : base (statusCode, title?? "Error", message) {
            Exception = exception;
        }

        public StackTrace StackTrace { get; } = new StackTrace (1, true);
        public Exception? Exception { get; }

    }
}