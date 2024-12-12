using System.Runtime.Serialization;

namespace HouseRent.Core.Domain.Framework;
public class DomainValidationException : Exception
{
    public DomainValidationException()
    {

    }

    public DomainValidationException(string? message) : base(message)
    {

    }

    public DomainValidationException(string? message, Exception? innerException) : base(message, innerException)
    {

    }

    public DomainValidationException(SerializationInfo? info, StreamingContext context) : base(info, context)
    {

    }
}
