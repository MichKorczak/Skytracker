namespace BuilderPart.Domain
{
    public class DomainException : Exception
    {
        protected DomainException(string message) : base(message) 
        { }
    }
}
