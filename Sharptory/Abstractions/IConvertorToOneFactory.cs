namespace Sharptory.Abstractions
{
    public interface IConvertorToOneFactory<Ttarget>
    {
        bool Redister<Tconvertor, Tsource>() where Tconvertor : IConvertor<Tsource, Ttarget>, new();
        bool Redister<Tsource>(Func<Tsource, Ttarget> func);
        Ttarget? Convert<Tsource>(Tsource source);
    }
}