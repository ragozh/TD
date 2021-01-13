using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Has Target Condition", menuName = "State Machines/Conditions/Tower/Has Target")]
public class HasTargetSO : StateConditionSO<HasTarget> { }

public class HasTarget : Condition
{
    private BasicTowerData _data;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicTowerData>();
    }
    protected override bool Statement()
    {
        return _data._currentTargetMonster != null;
    }
}