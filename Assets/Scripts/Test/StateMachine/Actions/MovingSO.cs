using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PlayerMoving", menuName = "State Machines/Actions/PlayerMoving")]
public class MovingSO : StateActionSO<Moving>
{
}

public class Moving : StateAction
{
    private PlayerData _playerData;
    private NavMeshAgent _navMeshAgent;
    public override void Awake(StateMachine stateMachine)
    {
        _playerData = stateMachine.GetComponent<PlayerData>();
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
    }
    public override void OnUpdate()
    {
        //Debug.DrawLine(_playerData.GetTargetPosition(), _playerData.GetTargetPosition() + Vector3.up * 5, Color.red, 5);
        _navMeshAgent.SetDestination(_playerData.GetTargetPosition());
    }
}
