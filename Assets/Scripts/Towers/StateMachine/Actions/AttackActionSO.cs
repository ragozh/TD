using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Attack Action", menuName = "State Machines/Actions/Tower/Attack Action")]
public class AttackActionSO : StateActionSO<AttackAction> { }

public class AttackAction : StateAction
{
    private TowerController _controller;
    public override void Awake(StateMachine stateMachine)
    {
        _controller = stateMachine.GetComponent<TowerController>();
    }
    public override void OnUpdate()
    {
    }
    public override void OnStateEnter()
    {
        _controller.AttackAction();
    }
}