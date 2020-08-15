using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Success {
    public class PartialContentDetail : ResultDetail {
        public PartialContentDetail (string title, string? message = null, object? moreDetails = null):
            base (StatusCodes.Status206PartialContent, title?? nameof (PartialContentDetail),
                message, moreDetails) { }
    }
}