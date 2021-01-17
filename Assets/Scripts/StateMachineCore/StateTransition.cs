using System;
using System.Linq;
using TD.StateMachine.ScriptableObjects;
using System.Collections.Generic;

namespace TD.StateMachine
{
	public class StateTransition : IStateComponent
	{
		private State _targetState;
        private Dictionary<StateCondition, Operator> _stateConditions;
        internal StateTransition() { }
        public StateTransition(State targetState, Dictionary<StateCondition, Operator> stateConditions)
        {
            Init(targetState, stateConditions);
        }
        internal void Init(State targetState, Dictionary<StateCondition, Operator> stateConditions)
        {
            _targetState = targetState;
            _stateConditions = stateConditions;
        }
        public bool TryGetTransition(out State state)
        {
            state = ShouldTransition() ? _targetState : null;
            return state != null;
        }
        public void OnStateEnter()
        {
            for (int i = 0; i < _stateConditions.Count; i++)
                _stateConditions.Keys.ElementAt(i)._condition.OnStateEnter();
                //_stateConditions[i]._condition.OnStateEnter();
        }
        public void OnStateExit()
        {
            for (int i = 0; i < _stateConditions.Count; i++)
                _stateConditions.Keys.ElementAt(i)._condition.OnStateExit();
                //_stateConditions[i]._condition.OnStateExit();
        }
        private bool ShouldTransition()
        {
            // TODO: Rescale logical math somehow
            bool results = true;
            for (int i = 0; i < _stateConditions.Count; i++)
            {
                if (i == 0) results = _stateConditions.Keys.ElementAt(i).IsMet(); 
                if (i == _stateConditions.Count - 1)    break;
                if (_stateConditions.Values.ElementAt(i) == Operator.And)
                    results = results && _stateConditions.Keys.ElementAt(i + 1).IsMet();
                else if (_stateConditions.Values.ElementAt(i) == Operator.Or)
                    results = results || _stateConditions.Keys.ElementAt(i + 1).IsMet();
            }
            return results;
        }
        internal void ClearConditionsCache()
		{
			for (int i = 0; i < _stateConditions.Count; i++)
				_stateConditions.Keys.ElementAt(i)._condition.ClearCacheFlag();
		}
    }
    
    [Serializable]
	public struct TransitionItem
	{
		public StateSO FromState;
		public StateSO ToState;
		public ConditionUsage[] ConditionUsages;
	}

	[Serializable]
	public struct ConditionUsage
	{
		public Result ExpectedResult;
		public StateConditionSO Condition;
		public Operator Operator;
	}

	public enum Result { True, False }
	public enum Operator { And, Or }
}
