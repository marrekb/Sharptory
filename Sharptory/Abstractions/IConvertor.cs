namespace Sharptory.Abstractions
{
    public interface IConvertor<Tsource, Ttarget>
    {
        Ttarget Convert(Tsource source);
    }
}