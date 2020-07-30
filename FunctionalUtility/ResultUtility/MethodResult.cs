namespace FunctionalUtility.ResultUtility {
    public sealed class MethodResult : MethodResultBase {
        private MethodResult (bool isSuccess, ResultDetail? detail = null) : base (isSuccess, detail) { }

        public static MethodResult Ok () {
            return new MethodResult (true);
        }

        public static MethodResult Ok (ResultDetail detail) {
            return new MethodResult (true, detail);
        }

        public static MethodResult Fail (ResultDetail detail) {
            return new MethodResult (false, detail);
        }
    }

    public sealed class MethodResult<T> : MethodResultBase {
        private MethodResult (T item, ResultDetail? detail = null) : base (true, detail) {
            Value = item;
        }

        private MethodResult (ResultDetail? detail = null) : base (false, detail) { }

        public T Value { get; }

        public static MethodResult<T> Ok (T item) {
            return new MethodResult<T> (item);
        }

        public static MethodResult<T> Ok (T item, ResultDetail detail) {
            return new MethodResult<T> (item, detail);
        }

        public static MethodResult<T> Fail (ResultDetail detail) {
            return new MethodResult<T> (detail);
        }
    }
}