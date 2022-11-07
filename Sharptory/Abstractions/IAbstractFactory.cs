namespace Sharptory.Abstractions
{
    public interface IAbstractFactory<Tkey, TcommonParent>
    {
        bool Register<Ttarget>(Tkey key) where Ttarget : TcommonParent, new ();
        bool Register(Tkey key, Func<TcommonParent?> func);
        public TcommonParent? Create(Tkey key);

    }
}