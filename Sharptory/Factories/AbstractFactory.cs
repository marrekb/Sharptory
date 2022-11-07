using Sharptory.Abstractions;

namespace Sharptory.Factories
{
    public class AbstractFactory<Tkey, TcommonParent> : IAbstractFactory<Tkey, TcommonParent> 
        where Tkey : notnull
    {
        private readonly Dictionary<Tkey, Func<TcommonParent?>> _functions;

        public AbstractFactory()
        {
            _functions = new Dictionary<Tkey, Func<TcommonParent?>>();
        }

        public bool Register<Ttarget>(Tkey key) where Ttarget : TcommonParent, new()
        {
            return Register(key, () => new Ttarget());
        }

        public bool Register(Tkey key, Func<TcommonParent?> func)
        {
            return _functions.TryAdd(key, func);
        }

        public TcommonParent? Create(Tkey key)
        {
            return _functions.TryGetValue(key, out var func) ? func() : default;
        }
    }
}