﻿using System;
using System.Diagnostics;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.ResultDetails {
    public class ErrorDetail : ResultDetail {
        public ErrorDetail (int statusCode, string? title = null, string? message = null,
            Exception? exception = null, bool showDefaultMessageToUser = true) : base (
            statusCode, title?? "Error", message ?? "No Data.") {
            Exception = exception;
            ShowDefaultMessageToUser = showDefaultMessageToUser;
        }

        private bool ShowDefaultMessageToUser { get; }

        public StackTrace StackTrace { get; } = new StackTrace (1, true);
        public Exception? Exception { get; }

        public override object GetViewModel () =>
            ShowDefaultMessageToUser ?
            new { StatusCode, Title = "Error!", Message = "something went wrong." } :
            new { StatusCode, Title, Message };
    }
}