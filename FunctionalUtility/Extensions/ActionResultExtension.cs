using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalUtility.Extensions {
    public class MethodResultObject : ObjectResult {
        public MethodResultObject (MethodResultBase methodResult, bool isDevelopMode = false):
            base (Extension.GetSuitableObject (methodResult.IsSuccess, null,
                methodResult.Detail, isDevelopMode)) {
                StatusCode = methodResult.Detail.StatusCode;
            }
    }

    public class MethodResultObject<T> : ObjectResult {
        public MethodResultObject (MethodResult<T> methodResult, bool isDevelopMode = false):
            base (Extension.GetSuitableObject (methodResult.IsSuccess, methodResult.Value,
                methodResult.Detail, isDevelopMode)) {
                StatusCode = methodResult.Detail.StatusCode;
            }
    }

    internal static class Extension {
        public static object? GetSuitableObject (bool isSuccess, object? value,
            ResultDetail detail, bool isDevelopMode) {
            if (isSuccess)
                return value;
            if (!isDevelopMode)
                return detail.GetViewModel ();
            return new { ResultInProductMode = detail.GetViewModel (), AllDetails = (object) detail };
        }
    }

    public static class ActionResultExtension {
        public static MethodResultObject ReturnMethodResult (
                this MethodResult methodResult, bool isDevelopMode = false) =>
            new MethodResultObject (methodResult, isDevelopMode);

        public static async Task<MethodResultObject> ReturnMethodResultAsync (
                this Task<MethodResult> methodResult, bool isDevelopMode = false) =>
            new MethodResultObject (await methodResult, isDevelopMode);

        public static MethodResultObject<T> ReturnMethodResult<T> (
                this MethodResult<T> methodResult, bool isDevelopMode = false) =>
            new MethodResultObject<T> (methodResult, isDevelopMode);

        public static async Task<MethodResultObject<T>> ReturnMethodResultAsync<T> (
                this Task<MethodResult<T>> methodResult, bool isDevelopMode = false) =>
            new MethodResultObject<T> (await methodResult, isDevelopMode);
    }
}