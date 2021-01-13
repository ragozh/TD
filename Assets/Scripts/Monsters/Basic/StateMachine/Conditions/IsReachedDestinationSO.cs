using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Is Reached Destination Condition", menuName = "State Machines/Conditions/Monster/Is Reached Destination")]
public class IsReachedDestinationSO : StateConditionSO<IsReachedDestination>
{
    public float distanceTreshold = 0.5f;
}

public class IsReachedDestination : Condition
{
    private BasicMonsterData _data;
    private IsReachedDestinationSO _originSO => (IsReachedDestinationSO)base.ThisSO;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicMonsterData>();
    }

    protected override bool Statement()
    {
        return _data.distanceToTarget < _originSO.distanceTreshold;
    }
    public override void OnStateExit()
	{
		_data.lastTargetDestination = _data.targetDestination;
	}
}
