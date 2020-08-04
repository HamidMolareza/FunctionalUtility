namespace FunctionalUtility.ResultUtility {
    public class ResultDetail {
        public ResultDetail (int statusCode, string title, string? message = null) {
            StatusCode = statusCode;
            Title = title;
            Message = message ?? "No data.";
        }

        public int StatusCode { get; }
        public string Title { get; }
        public string Message { get; }

        public virtual object GetViewModel () =>
            new { StatusCode, Title, Message };
    }
}