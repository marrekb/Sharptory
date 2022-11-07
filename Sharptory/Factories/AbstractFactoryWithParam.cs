using Sharptory.Abstractions;

namespace Sharptory.Factories
{
    public class AbstractFactoryWithParam<Tkey, TcommonParent, Tparam> : IAbstractFactoryWithParam<Tkey, TcommonParent, Tparam>
        where Tkey : notnull
    {
        private readonly Dictionary<Tkey, Func<Tparam, TcommonParent?>> _functions;

        public AbstractFactoryWithParam()
        {
            _functions = new Dictionary<Tkey, Func<Tparam, TcommonParent?>>();
        }

        public bool Register(Tkey key, Func<Tparam, TcommonParent?> func)
        {
            return _functions.TryAdd(key, func);
        }

        public TcommonParent? Create(Tkey key, Tparam param)
        {
            return _functions.TryGetValue(key, out var func) ? func(param) : default;
        }
    }
}