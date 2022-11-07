namespace Sharptory.Abstractions
{
    public interface IMediator
    {
        bool Register<Tparameter, Texecutor>() where Texecutor : IExecutable<Tparameter>, new();
        bool Register<Tparam>(Action<Tparam> action);
        bool Execute<Tparam>(Tparam param);
    }
}