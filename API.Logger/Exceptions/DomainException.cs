namespace API.Logger.Exceptions
{
    public class DomainException : Exception
    {
        public int Code { get; }
        public string Title { get; }

        public DomainException(string title, string message, int code) : base(message)
        {
            Code = code;
            Title = title;
        }

    }
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base("Not Found", message, 404)
        {
        }
    }
}
