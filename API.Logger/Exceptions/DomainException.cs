namespace API.Logger.Exceptions
{
    public class DomainException : Exception
    {
        public int Code { get; }
        public DomainException(string message, int code) : base(message)
        {
            Code = code;
        }

    }
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message, 404)
        {
        }
    }
}
