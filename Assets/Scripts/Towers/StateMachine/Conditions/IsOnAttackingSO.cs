using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Is Attacking Condition", menuName = "State Machines/Conditions/Tower/Is Attacking")]
public class IsOnAttackingSO : StateConditionSO<IsOnAttacking> { }

public class IsOnAttacking : Condition
{
    private BasicTowerData _data;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicTowerData>();
    }
    protected override bool Statement()
    {
        return _data.isOnAttacking;
    }
}