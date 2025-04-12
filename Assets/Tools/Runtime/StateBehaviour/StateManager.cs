using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace Tools.Runtime.StateBehaviour
{
    public abstract class StateManager<T> : IDisposable where T : class, IState
    {
        public readonly UnityEvent<T> StateChanged = new();

        private readonly Dictionary<Type, T> _statesMap;
        private T _state;
        
        public T Current
        {
            get => _state;
            protected set
            {
                _state?.Dispose();
                _state = value;
                _state.Initialize();
                StateChanged.Invoke(_state);
            }
        }
        
        protected StateManager(T[] states)
        {
            _statesMap = states.ToDictionary(state => state.GetType(), state => state);
            _state = null;
        }

        public void SwitchToState<T1>()
        {
            SwitchToState(typeof(T1));
        }

        public void SwitchToState(Type type)
        {
            Current = _statesMap[type];
        }
        
        public void Dispose()
        {
            _state?.Dispose();
            _state = null;
            _statesMap.Clear();
        }
    }
}