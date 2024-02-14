namespace UniqueHabits.Contracts.Api
{
    public class ApiResult
    {
        protected ApiResult() { }
        protected ApiResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public static ApiResult Success()
        {
            return new ApiResult(true, "");
        }

        public static ApiResult Failure(string message)
        {
            return new ApiResult (false, message);
        }
        
        public static ApiResult Failure()
        {
            return Failure("Unknown error");
        }
    }

    public class ApiResult<T> : ApiResult
    {
        private ApiResult(string message) : base(false, message)
        {
            Value = default;
        }
        private ApiResult(T value) : base(true, string.Empty)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public static ApiResult<T> Success(T value)
        {
            return new ApiResult<T>(value);
        }

        public static new ApiResult<T> Failure(string message)
        {
            return new ApiResult<T>(message);
        }

        public static new ApiResult<T> Failure()
        {
            return Failure("Unknown error");
        }
    }
}
