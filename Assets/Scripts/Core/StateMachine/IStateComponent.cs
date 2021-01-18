namespace TD.StateMachine
{
    interface IStateComponent
    {
        void OnStateEnter();
        void OnStateExit();
    }
}