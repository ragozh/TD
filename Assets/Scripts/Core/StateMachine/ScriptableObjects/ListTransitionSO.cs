using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace TD.StateMachine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New List Transition", menuName = "State Machines/List Transition")]
    public class ListTransitionSO : ScriptableObject
    {    
        [SerializeField] private StateTransitionSO[] _stateTransitions = default;
        internal State GetInitialState(StateMachine stateMachine)
        {
            var states = new List<State>();
            var stateTransitions = new List<StateTransition>();
            var createdInstances = new Dictionary<ScriptableObject, object>();
            
            // Get from stateSO from list
            var fromStates = _stateTransitions.GroupBy(x => x.GetTransitionItem().FromState);
            foreach (var fromState in fromStates)
            {
                if (fromState.Key == null)
					throw new ArgumentNullException(nameof(fromState.Key), $"ListTransition: State {name} not exists.");
                // get from state
                var state = fromState.Key.GetState(stateMachine, createdInstances);
                states.Add(state);                
                stateTransitions.Clear(); // all stateTransitions belong to from state
                foreach (var stateTransitionSO in fromState)
                {
                    // get each toStateSO from fromState
                    var toStateSO = stateTransitionSO.GetTransitionItem().ToState;
                    if (toStateSO == null)
                        throw new ArgumentNullException(nameof(toStateSO),
                            $"ListTransition: {name}, from State: {fromState.Key.name}");
                    // get toState
                    var toState = toStateSO.GetState(stateMachine, createdInstances);
                    ProcessConditionUsages(stateMachine, stateTransitionSO.GetTransitionItem().ConditionUsages, 
                        createdInstances, out var stateConditions);
                    stateTransitions.Add(new StateTransition(toState, stateConditions));
                }
                state._stateTransitions = stateTransitions.ToArray();
            }

            return states.Count > 0 
                ? states[0] 
                : throw new InvalidOperationException($"ListTransition {name} is empty.");
        }
        private static void ProcessConditionUsages(
            StateMachine stateMachine,
            ConditionUsage[] conditionUsages,
            Dictionary<ScriptableObject, object> createdInstances,
            out Dictionary<StateCondition, Operator> stateConditions
        )
        {
            int count = conditionUsages.Length;
			stateConditions = new Dictionary<StateCondition, Operator>();
            for (int i = 0; i < count; i++)
                stateConditions.Add(conditionUsages[i].Condition.GetCondition(
                    stateMachine,
                    conditionUsages[i].ExpectedResult == Result.True,
                    createdInstances), conditionUsages[i].Operator);            
        }
    }
}
