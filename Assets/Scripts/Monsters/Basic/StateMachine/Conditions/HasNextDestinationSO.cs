using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Has Next Destination Condition", menuName = "State Machines/Conditions/Has Next Destination")]
public class HasNextDestinationSO : StateConditionSO<HasNextDestination> { }

public class HasNextDestination : Condition
{
    private BasicMonsterData _data;
    private NavMeshAgent _navMeshAgent;
    public override void Awake(StateMachine stateMachine)
    {
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        _data = stateMachine.GetComponent<BasicMonsterData>();
    }
    protected override bool Statement()
    {
        return _navMeshAgent.destination != _data.lastTargetDestination;
    }
    
    public override void OnStateExit()
    { 
        _data.lastTargetDestination = _data.targetDestination;
    }
}