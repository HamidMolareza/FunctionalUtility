using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Success {
    public class AcceptedDetail : ResultDetail {
        public AcceptedDetail (string title, string? message = null, object? moreDetails = null):
            base (StatusCodes.Status202Accepted, title ?? nameof (AcceptedDetail),
                message, moreDetails) { }
    }
}