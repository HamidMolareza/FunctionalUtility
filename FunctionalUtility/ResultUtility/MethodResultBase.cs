using Microsoft.AspNetCore.Http;

namespace FunctionalUtility.ResultUtility {
    public abstract class MethodResultBase {
        protected MethodResultBase (bool isSuccess, ResultDetail? detail = null) {
            IsSuccess = isSuccess;
            Detail = detail ?? new ResultDetail (
                isSuccess ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError,
                title: "No Data!", message: "That's all we know.");
        }

        public bool IsSuccess { get; }
        public ResultDetail Detail { get; }
    }
}