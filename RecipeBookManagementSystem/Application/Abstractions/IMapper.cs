namespace Application.Abstractions
{
    public interface IMapper<TSource, TDestination> where TDestination : new()
    {
        object Map(object source);
    }
}
