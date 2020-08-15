using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Success {
    public class NotModifiedDetail : ResultDetail {
        public NotModifiedDetail (string? title = null, string? message = null, object? moreDetails = null):
            base (StatusCodes.Status304NotModified, title ?? nameof (NotModifiedDetail),
                message, moreDetails) { }
    }
}