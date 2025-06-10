using Core.Application.Bases;

namespace Core.Application.Features.Brand.Exceptions;

public class BrandNotFoundException : BaseExceptions
{
    public BrandNotFoundException() : base("Brand not found!") { }
    public BrandNotFoundException(string message) : base(message) { }
}