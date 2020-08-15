using FunctionalUtility.ResultUtility;
using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultDetails.Success {
    public class CreatedDetail : ResultDetail {
        public CreatedDetail (string title, string? message = null, object? moreDetails = null):
            base (StatusCodes.Status201Created, title ?? nameof (CreatedDetail), message, moreDetails) { }
    }
}