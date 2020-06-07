namespace ItAcademy.SchoolAdmin.Infrastructure
{
    public class Result
    {
        protected Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        public string Message { get; }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
    }
}
