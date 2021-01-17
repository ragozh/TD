using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Is Attacking Condition", menuName = "State Machines/Conditions/Tower/Is Attacking")]
public class IsOnAttackingSO : StateConditionSO<IsOnAttacking> { }

public class IsOnAttacking : Condition
{
    private TowerController _controller;
    public override void Awake(StateMachine stateMachine)
    {
        _controller = stateMachine.GetComponent<TowerController>();
    }
    protected override bool Statement()
    {
        return _controller.IsOnAttacking();
    }
}