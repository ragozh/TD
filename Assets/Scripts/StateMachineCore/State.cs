using TD.StateMachine.ScriptableObjects;

namespace TD.StateMachine
{
	public class State
	{
		internal StateSO _thisSO;
		internal StateMachine _stateMachine;
		internal StateTransition[] _stateTransitions;
		internal StateAction[] _actions;

		internal State() { }

		public State(StateSO originSO, StateMachine stateMachine,
            StateTransition[] transitions, StateAction[] actions)
		{
			_thisSO = originSO;
			_stateMachine = stateMachine;
			_stateTransitions = transitions;
			_actions = actions;
		}
		public void OnStateEnter()
		{
			void OnStateEnter(IStateComponent[] comps)
			{
				for (int i = 0; i < comps.Length; i++)
					comps[i].OnStateEnter();
			}
			OnStateEnter(_stateTransitions);
			OnStateEnter(_actions);
		}
		public void OnUpdate()
		{
			for (int i = 0; i < _actions.Length; i++)
				_actions[i].OnUpdate();
		}
		public void OnStateExit()
		{
			void OnStateExit(IStateComponent[] comps)
			{
				for (int i = 0; i < comps.Length; i++)
					comps[i].OnStateExit();
			}
			OnStateExit(_stateTransitions);
			OnStateExit(_actions);
		}
		public bool TryGetTransition(out State state)
		{
			state = null;

			for (int i = 0; i < _stateTransitions.Length; i++)
				if (_stateTransitions[i].TryGetTransition(out state))
					break;

			for (int i = 0; i < _stateTransitions.Length; i++)
				_stateTransitions[i].ClearConditionsCache();

			return state != null;
		}
	}
}
