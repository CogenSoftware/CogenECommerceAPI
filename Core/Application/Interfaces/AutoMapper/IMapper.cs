namespace Core.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, string? ignore = null);
        IList<TDestination> Map<TSource, TDestination>(IList<TSource> source, string? ignore = null);
        TDestination Map<TSource, TDestination>(object source, string? ignore = null);
        IList<TDestination> Map<TSource, TDestination>(IList<object> source, string? ignore = null);
    }
}