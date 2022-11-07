using Sharptory.Abstractions;

namespace Sharptory.Factories
{
    public class ConvertorToManyFactory<Tkey, Tsource> : IConvertorToManyFactory<Tkey, Tsource>
        where Tkey : notnull
    {
        private readonly Dictionary<Tkey, Func<Tsource, object?>> _convertors;

        public ConvertorToManyFactory()
        {
            _convertors = new Dictionary<Tkey, Func<Tsource, object?>>();
        }

        public bool Redister<Tconvertor, Ttarget>(Tkey key) where Tconvertor : IConvertor<Tsource, Ttarget>, new()
        {
            return Redister(key, (source) => new Tconvertor().Convert(source));
        }

        public bool Redister(Tkey key, Func<Tsource, object?> func) 
        {
            return _convertors.TryAdd(key, func);
        }

        public object? Convert(Tkey key, Tsource source)
        {
            return _convertors.TryGetValue(key, out var convertor) ? convertor(source) : default;
        }
    }
}