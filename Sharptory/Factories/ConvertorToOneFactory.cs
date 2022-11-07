using Sharptory.Abstractions;

namespace Sharptory.Factories
{
    public class ConvertorToOneFactory<Ttarget> : IConvertorToOneFactory<Ttarget>
    {
        private readonly Dictionary<Type, Func<object?, Ttarget>> _convertors;

        public ConvertorToOneFactory()
        {
            _convertors = new Dictionary<Type, Func<object?, Ttarget>>();
        }

        public bool Redister<Tconvertor, Tsource>() where Tconvertor : IConvertor<Tsource, Ttarget>, new()
        {
            return Redister<Tsource>((source) => new Tconvertor().Convert(source));
        }

        public bool Redister<Tsource>(Func<Tsource, Ttarget> func)
        {
            Func<object?, Ttarget> funcObject = (source) => func((Tsource) source);
            return _convertors.TryAdd(typeof(Tsource), funcObject);
        }

        public Ttarget? Convert<Tsource>(Tsource source)
        {
            return _convertors.TryGetValue(typeof(Tsource), out var convertor) ? convertor(source) : default;
        }
    }
}