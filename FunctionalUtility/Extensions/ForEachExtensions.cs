using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalUtility.ResultDetails;
using FunctionalUtility.ResultDetails.Errors;
using FunctionalUtility.ResultUtility;

namespace FunctionalUtility.Extensions {

    public static class ForEachExtensions {

        #region ForEachUntilIsSuccess

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

        public static MethodResult ForEachUntilIsSuccess<T> (
            this IEnumerable<T> @this,
            Action<T> action) {
            var list = @this.ToList ();
            foreach (var item in list) {
                try {
                    action (item);
                } catch (Exception e) {
                    return MethodResult.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = list, targetItem = item }));
                }
            }
            return MethodResult.Ok ();
        }

        #endregion

        #region ForEachUntilIsSuccessAsync

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

        public static async Task<MethodResult> ForEachUntilIsSuccessAsync<T> (
            this IEnumerable<T> @this,
            Func<T, Task> action) {
            var list = @this.ToList ();
            foreach (var item in list) {
                try {
                    await action (item);
                } catch (Exception e) {
                    return MethodResult.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = list, targetItem = item }));
                }
            }
            return MethodResult.Ok ();
        }

        #endregion

        #region SelectResults

        public static MethodResult<List<TResult>> SelectResults<TSource, TResult> (
            this IEnumerable<TSource> @this,
            Func<TSource, MethodResult<TResult>> function) {
            var thisList = @this.ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                var result = function (item);
                if (!result.IsSuccess) {
                    result.Detail.AddDetail (new { thisObj = thisList, targetItem = item });
                    return MethodResult<List<TResult>>.Fail (result.Detail);
                }
                selectedResult.Add (result.Value);
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static MethodResult<List<TResult>> SelectResults<TSource, TResult> (
            this IEnumerable<TSource> @this,
            Func<TSource, TResult> function) {
            var thisList = @this.ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                try {
                    var result = function (item);
                    selectedResult.Add (result);
                } catch (Exception e) {
                    return MethodResult<List<TResult>>.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = thisList, targetItem = item }));
                }
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        #endregion

        #region SelectResultsAsync

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this Task<IEnumerable<TSource>> @this,
            Func<TSource, MethodResult<TResult>> function) {
            var thisList = (await @this).ToList ();
            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                var result = function (item);
                if (!result.IsSuccess) {
                    result.Detail.AddDetail (new { thisObj = @this, targetItem = item });
                    return MethodResult<List<TResult>>.Fail (result.Detail);
                }
                selectedResult.Add (result.Value);
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this IEnumerable<TSource> @this,
            Func<TSource, Task<MethodResult<TResult>>> function) {
            var thisList = @this.ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                var result = await function (item);
                if (!result.IsSuccess) {
                    result.Detail.AddDetail (new { thisObj = thisList, targetItem = item });
                    return MethodResult<List<TResult>>.Fail (result.Detail);
                }
                selectedResult.Add (result.Value);
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this Task<IEnumerable<TSource>> @this,
            Func<TSource, Task<MethodResult<TResult>>> function) {
            var thisList = (await @this).ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                var result = await function (item);
                if (!result.IsSuccess) {
                    result.Detail.AddDetail (new { thisObj = @this, targetItem = item });
                    return MethodResult<List<TResult>>.Fail (result.Detail);
                }
                selectedResult.Add (result.Value);
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this Task<IEnumerable<TSource>> @this,
            Func<TSource, TResult> function) {
            var thisList = (await @this).ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                try {
                    var result = function (item);
                    selectedResult.Add (result);
                } catch (Exception e) {
                    return MethodResult<List<TResult>>.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = thisList, targetItem = item }));
                }
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this IEnumerable<TSource> @this,
            Func<TSource, Task<TResult>> function) {
            var thisList = @this.ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                try {
                    var result = await function (item);
                    selectedResult.Add (result);
                } catch (Exception e) {
                    return MethodResult<List<TResult>>.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = thisList, targetItem = item }));
                }
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        public static async Task<MethodResult<List<TResult>>> SelectResultsAsync<TSource, TResult> (
            this Task<IEnumerable<TSource>> @this,
            Func<TSource, Task<TResult>> function) {
            var thisList = (await @this).ToList ();

            var selectedResult = new List<TResult> (thisList.Count);
            foreach (var item in thisList) {
                try {
                    var result = await function (item);
                    selectedResult.Add (result);
                } catch (Exception e) {
                    return MethodResult<List<TResult>>.Fail (new ExceptionError (e,
                        moreDetails : new { thisObj = thisList, targetItem = item }));
                }
            }

            return MethodResult<List<TResult>>.Ok (selectedResult);
        }

        #endregion

    }
}