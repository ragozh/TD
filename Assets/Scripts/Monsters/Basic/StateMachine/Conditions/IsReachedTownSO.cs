using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "Is Reached Town Condition", menuName = "State Machines/Conditions/Is Reached Town")]
public class IsReachedTownSO : StateConditionSO<IsReachedTown> { }

public class IsReachedTown : Condition
{
    BasicMonsterData _data;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicMonsterData>();
    }
    protected override bool Statement()
    {
        return _data.reachedTown;
    }
}