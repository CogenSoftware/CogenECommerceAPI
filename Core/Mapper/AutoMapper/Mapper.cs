using AutoMapper;
using AutoMapper.Internal;

namespace Core.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        private static List<TypePair> typePairs = new();
        private IMapper MapperContainer = null!;

        public TDestination Map<TSource, TDestination>(TSource source, string? ignore = null)
        {
            Config<TSource, TDestination>(5, ignore);
            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TSource, TDestination>(IList<TSource> source, string? ignore = null)
        {
            Config<TSource, TDestination>(5, ignore);
            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TSource, TDestination>(object source, string? ignore = null)
        {
            Config<TSource, TDestination>(5, ignore);
            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TSource, TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TSource, TDestination>(5, ignore);
            return MapperContainer.Map<IList<object>, IList<TDestination>>(source);
        }

        private void Config<TSource, TDestination>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(x => x.SourceType == typePair.SourceType && x.DestinationType == typePair.DestinationType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var pair in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}
