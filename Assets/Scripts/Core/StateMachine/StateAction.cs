using TD.StateMachine.ScriptableObjects;

namespace TD.StateMachine
{
	public abstract class StateAction : IStateComponent
	{
		internal StateActionSO _thisSO;
		protected StateActionSO OriginSO => _thisSO;
		public abstract void OnUpdate();
        public virtual void Awake(StateMachine stateMachine) { }
		public virtual void OnStateEnter() { }
		public virtual void OnStateExit() { }
		public enum SpecificMoment
		{
			OnStateEnter, OnStateExit, OnUpdate,
		}
	}
}
