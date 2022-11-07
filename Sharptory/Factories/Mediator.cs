using Sharptory.Abstractions;

namespace Sharptory.Factories
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, Action<object>> _executors;

        public Mediator()
        {
            _executors = new Dictionary<Type, Action<object>>();
        }

        public bool Register<Tparameter, Texecutor>() where Texecutor : IExecutable<Tparameter>, new()
        {
            return Register<Tparameter>((param) => new Texecutor().Execute(param));
        }

        public bool Register<Tparam>(Action<Tparam> action)
        {
            Action<object> actionObject = (param) => action((Tparam)param);
            return _executors.TryAdd(typeof(Tparam), actionObject);
        }

        public bool Execute<Tparam>(Tparam param)
        {
            var found = _executors.TryGetValue(typeof(Tparam), out var action);
            if (found)
            {
                action(param);
                return true;
            }
            return false;
        }
    }
}