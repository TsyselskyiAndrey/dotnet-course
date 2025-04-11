using Application.Abstractions;

namespace Infrastructure.Mappers
{
    public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination> where TDestination : new()
    {
        public object Map(object source)
        {
            if (source == null) return default;

            if (source is TSource single)
            {
                return MapOneObject(single);
            }

            if (source is IEnumerable<TSource> list)
            {
                return list.Select(x => MapOneObject(x)).ToList();
            }

            throw new ArgumentException("Unsupported source type");
        }

        private TDestination MapOneObject(TSource source)
        {
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
    }

}
