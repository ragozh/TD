using System.Collections.Generic;
using UnityEngine;

namespace TD.StateMachine.ScriptableObjects
{    
    [CreateAssetMenu(fileName = "New State", menuName = "State Machines/State")]
    public class StateSO : ScriptableObject
    {
		[SerializeField] private StateActionSO[] _actions = null;
        internal State GetState(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
        {
            if (!createdInstances.TryGetValue(this, out var obj))
            {
                var state = new State();
                state._thisSO = this;
                createdInstances.Add(this, state);
                state._stateMachine = stateMachine;

                state._actions = GetAction(stateMachine, _actions, createdInstances);
                state._stateTransitions = new StateTransition[0];

                obj = state;
            }
            return (State)obj;
        }

        private static StateAction[] GetAction(StateMachine stateMachine, StateActionSO[] actionSOs,
            Dictionary<ScriptableObject, object> createdInstances)
        {
            int count = actionSOs.Length;
            var actions = new StateAction[count];
            for (int i = 0; i < count; i++)
                actions[i] = actionSOs[i].GetAction(stateMachine, createdInstances);
            return actions;
        }
    }
}