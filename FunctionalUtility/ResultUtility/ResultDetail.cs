using System.Collections.Generic;

namespace FunctionalUtility.ResultUtility {
    public class ResultDetail {
        public ResultDetail (int statusCode, string title,
            string? message = null, object ? moreDetail = null) {
            StatusCode = statusCode;
            Title = title;
            Message = message ?? "No data.";
            if (moreDetail != null)
                MoreDetails = new List<object> { moreDetail };
        }

        public int StatusCode { get; }
        public string Title { get; }
        public string Message { get; }
        public List<object> ? MoreDetails { get; private set; }

        public virtual object GetViewModel () =>
            new { StatusCode, Title, Message };

        public void AddDetail (object newDetail) {
            if (newDetail is null)
                return;
            if (MoreDetails is null)
                MoreDetails = new List<object> ();
            MoreDetails.Add (newDetail);
        }
    }
}