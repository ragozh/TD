using TD.StateMachine.ScriptableObjects;

namespace TD.StateMachine
{
    public readonly struct StateCondition
    {
        internal readonly StateMachine _stateMachine;
        internal readonly Condition _condition;
        internal readonly bool _expected;
        public StateCondition(StateMachine stateMachine, Condition condition, bool expected)
        {
            _stateMachine = stateMachine;
            _condition = condition;
            _expected = expected;
        }
        public bool IsMet()
        {
            var statement = _condition.GetStatement();
            return statement == _expected;
        }
    }
    public abstract class Condition : IStateComponent
	{
		private bool _isCached = false;
        private bool _cachedStatement;
        internal StateConditionSO _thisSO;
        protected StateConditionSO ThisSO => _thisSO;
        protected abstract bool Statement(); // must be method
        internal bool GetStatement()
        {
            if (!_thisSO.cacheResult)
                return Statement();
            if (!_isCached)
            {
                _isCached = true;
                _cachedStatement = Statement();
            }
            return _cachedStatement;
        }
        internal void ClearCacheFlag()
        {
            _isCached = false;
        }
        public virtual void Awake(StateMachine stateMachine) { }
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
    }
}
