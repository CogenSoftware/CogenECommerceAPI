using Core.Application.Bases;

namespace Core.Application.Features.Brand.Exceptions;

public class BrandNameMustBeUniqueException : BaseExceptions
{
    public BrandNameMustBeUniqueException() : base("The brand name cannot be the same!") { }
    public BrandNameMustBeUniqueException(string message) : base(message) { }
}

public class BrandNotFoundException : BaseExceptions
{
    public BrandNotFoundException() : base("Brand not found!") { }
    public BrandNotFoundException(string message) : base(message) { }
}