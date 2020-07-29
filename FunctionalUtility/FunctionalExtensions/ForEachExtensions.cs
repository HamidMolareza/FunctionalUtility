using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.FunctionalExtensions {
    public static class ForEachExtensions {
        public static MethodResult ForEachUntilIsSuccess<T> (
            this IEnumerable<T> @this,
            Func<T, MethodResult> function) {
            foreach (var item in @this) {
                var result = function (item);
                if (!result.IsSuccess)
                    return result;
            }
            return MethodResult.Ok ();
        }

        public static async Task<MethodResult> ForEachUntilIsSuccessAsync<T> (
            this IEnumerable<T> @this,
            Func<T, Task<MethodResult>> function) {
            foreach (var item in @this) {
                var result = await function (item);
                if (!result.IsSuccess)
                    return result;
            }
            return MethodResult.Ok ();
        }

        public static MethodResult<List<TResult>> SelectResults<TSource, TResult> (
            this List<TSource> @this,
            Func<TSource, MethodResult<TResult>> function) {

            var selectedResult = new List<TResult> (@this.Count);
            foreach (var item in @this) {
                var result = function (item);
                if (!result.IsSuccess)
                    return MethodResult<List<TResult>>.Fail (result.Detail);
                selectedResult.Add (result.Value);
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }
    }
}