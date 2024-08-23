namespace Helper
{
    public class CustomException : Exception
    {
        public string ErrorType { get; }

        public CustomException(string errorType, string message) : base(message)
        {
            ErrorType = errorType;
        }
    }
}