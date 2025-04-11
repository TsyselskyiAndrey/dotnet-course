namespace Application.Abstractions
{
    public interface IMapper<TSource, TDestination> where TDestination : new()
    {
        TDestination Map(TSource source);
        List<TDestination> Map(List<TSource> sourceList);
    }
}
