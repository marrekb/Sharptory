namespace Sharptory.Abstractions
{
    public interface IAbstractFactoryWithParam<Tkey, TcommonParent, Tparam>
    {
        bool Register(Tkey key, Func<Tparam, TcommonParent?> func);
        TcommonParent? Create(Tkey key, Tparam param);
    }
}