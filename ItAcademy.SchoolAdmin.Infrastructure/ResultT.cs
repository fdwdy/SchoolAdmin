namespace ItAcademy.SchoolAdmin.Infrastructure
{
    public class Result<T> : Result
        where T : class
    {
        protected Result(bool success, string message, T data)
            : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }

        public static Result<T> Ok<T>(T data)
            where T : class
        {
            return new Result<T>(true, null, data);
        }

        public static Result<T> Fail<T>(T data, string message)
            where T : class
        {
            return new Result<T>(false, message, data);
        }
    }
}
