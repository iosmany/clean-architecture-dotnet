namespace ecommerce.core
{
    public interface IError
    {
        string? Field { get; }
        string Message { get; }
    }

    public static class ErrorFactory
    {
        public class Error : IError
        {
            public string? Field { get; set; }
            public string Message { get; set; }
            public Error(string message, string? field = null)
            {
                Message = message;
                Field= field;
            }
        }

        public static IError New(string message, string? field = null) 
            => new Error(message, field);
        public static IReadOnlyCollection<IError> Multiple(params string[] messages)
            => messages.Select(m => new Error(m)).ToList();

    }
}
