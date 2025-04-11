using Application.Abstractions;

namespace Infrastructure.Mappers
{
    public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination> where TDestination : new()
    {
        public TDestination Map(TSource source)
        {
            if (source == null) return default;

            var destination = new TDestination();

            foreach (var sourceProperty in typeof(TSource).GetProperties())
            {
                var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);

                if (destinationProperty != null &&
                    destinationProperty.CanWrite &&
                    destinationProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }

        public List<TDestination> Map(List<TSource> sourceList)
        {
            if (sourceList == null) return new List<TDestination>();
            return sourceList.Select(x => Map(x)).ToList();
        }
    }

}
