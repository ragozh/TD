using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Alway True Condition", menuName = "State Machines/Conditions/Alway True")]
public class IsAlwayTrueSO : StateConditionSO<IsAlwayTrue> { }

public class IsAlwayTrue : Condition
{
    protected override bool Statement()
    {
        return true;
    }
}
