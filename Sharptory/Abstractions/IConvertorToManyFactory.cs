namespace Sharptory.Abstractions
{
    public interface IConvertorToManyFactory<Tkey, Tsource>
    {
        bool Redister<Tconvertor, Ttarget>(Tkey key) where Tconvertor : IConvertor<Tsource, Ttarget>, new();
        bool Redister(Tkey key, Func<Tsource, object?> func);
        object? Convert(Tkey key, Tsource source);
    }
}
