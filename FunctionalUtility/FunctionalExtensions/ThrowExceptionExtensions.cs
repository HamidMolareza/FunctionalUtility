using System;
using System.Text.Json;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
    public static class ThrowExceptionExtensions {
       
        #region ThrowException

        //TODO: Check
        public static void ThrowException (this ResultDetail @this) {
            throw @this
            switch {
                ExceptionError exceptionError when exceptionError.Exception != null => exceptionError.Exception,
                ErrorDetail errorDetail => new Exception (JsonSerializer.Serialize (errorDetail)),
                    _ => new Exception (JsonSerializer.Serialize (@this)),
            };
        }

        public static void ThrowException<T> (
            this T _,
            ResultDetail resultDetail) => resultDetail.ThrowException ();

        #endregion

        #region ThrowExceptionOnFail

        public static MethodResult<T> ThrowExceptionOnFail<T> (
                this MethodResult<T> @this,
                Action? exception = null) => @this
            .OnFail (_ => _
                .Tee (exception)
                .Tee (() => ThrowException (@this.Detail)));

        public static MethodResult ThrowExceptionOnFail (
                this MethodResult @this,
                Action? exception = null) => @this
            .OnFail (_ => _
                .Tee (exception)
                .Tee (() => ThrowException (@this.Detail)));

        #endregion

    }
}