using System.Collections.Generic;
using UnityEngine;

namespace TD.StateMachine.ScriptableObjects
{
    public abstract class StateConditionSO<T> : StateConditionSO where T : Condition, new()
    {
        protected override Condition CreateCondition() => new T();
    }
    public abstract class StateConditionSO : ScriptableObject
    {
        [SerializeField]
        internal bool cacheResult = true;
        internal StateCondition GetCondition(StateMachine stateMachine, bool expected, 
            Dictionary<ScriptableObject, object> createdInstances)
        {
            if (!createdInstances.TryGetValue(this, out var obj))
            {
                var condition = CreateCondition();
                condition._thisSO = this;
                createdInstances.Add(this, condition);
                condition.Awake(stateMachine);

                obj = condition;
            }
            return new StateCondition(stateMachine, (Condition)obj, expected);
        }
        protected abstract Condition CreateCondition();
    }
}