namespace Sharptory.Abstractions
{
    public interface IExecutable<Tparam>
    {
        void Execute(Tparam param);
    }
}