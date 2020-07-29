using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalUtility.FunctionalExtensions {
    public class MethodResultObject : ObjectResult {
        public MethodResultObject (MethodResultBase methodResult):
            base (methodResult.IsSuccess ? null : methodResult.Detail) {
                StatusCode = methodResult.Detail.StatusCode;
            }
    }

    public class MethodResultObject<T> : ObjectResult {
        public MethodResultObject (MethodResult<T> methodResult):
            base (methodResult.IsSuccess ? (object) methodResult.Value! : methodResult.Detail) {
                StatusCode = methodResult.Detail.StatusCode;
            }
    }

    public static class ActionResultExtension {
        public static MethodResultObject ReturnMethodResult (
            this MethodResult value) => new MethodResultObject (value);

        public static async Task<MethodResultObject> ReturnMethodResultAsync (
            this Task<MethodResult> value) => new MethodResultObject (await value);

        public static MethodResultObject<T> ReturnMethodResult<T> (
            this MethodResult<T> value) => new MethodResultObject<T> (value);

        public static async Task<MethodResultObject<T>> ReturnMethodResultAsync<T> (
            this Task<MethodResult<T>> value) => new MethodResultObject<T> (await value);
    }
}