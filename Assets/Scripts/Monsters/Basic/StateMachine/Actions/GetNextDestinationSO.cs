using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Get Next Destination Action", menuName = "State Machines/Actions/Get Next Destination")]
public class GetNextDestinationSO : StateActionSO<GetNextDestination> { }

public class GetNextDestination : StateAction
{
    private BasicMonsterData _data;
    private NavMeshAgent _navMeshAgent;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicMonsterData>();
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
    }

    public override void OnStateEnter()
    { 
        if (_data.listCheckPoints.Count > 0)
        {
            _data.targetDestination = _data.listCheckPoints.Dequeue();
            _navMeshAgent.SetDestination(_data.targetDestination);
        }
    }

    public override void OnUpdate() { }
}
