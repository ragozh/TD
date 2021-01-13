using System.Collections.Generic;
using UnityEngine;

namespace TD.StateMachine.ScriptableObjects
{
    public abstract  class StateActionSO : ScriptableObject
    {
        internal StateAction GetAction(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (!createdInstances.TryGetValue(this, out var obj))
            {
                var action = CreateAction();
                action._thisSO = this;
                createdInstances.Add(this, action);
                action.Awake(stateMachine);

                obj = action;
            }
            return (StateAction)obj;
        }
        protected abstract StateAction CreateAction();
    }
    public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
    {
        protected override StateAction CreateAction() => new T();
    }
}