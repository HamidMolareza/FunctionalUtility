namespace FunctionalUtility.ResultUtility {
    public abstract class MethodResultBase {
        protected MethodResultBase (bool isSuccess, ResultDetail? detail = null) {
            IsSuccess = isSuccess;
            Detail = detail ?? new ResultDetail (-1, title: "No Data!", message: "That's all we know.");
        }

        public bool IsSuccess { get; }
        public ResultDetail Detail { get; }
    }
}