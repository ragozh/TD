using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "CalculateDistanceAction", menuName = "State Machines/Actions/Calculate Distance")]
public class CalculateDistanceToDestinationSO : StateActionSO<CalculateDistanceToDestination> { }

public class CalculateDistanceToDestination : StateAction
{
    // Component references
    private BasicMonsterData _data;
    private Transform _transform;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicMonsterData>();
        _transform = stateMachine.GetComponent<Transform>();
    }
    public override void OnUpdate()
    {
        _data.distanceToTarget = (_data.targetDestination - _transform.position).magnitude;
    }
}
