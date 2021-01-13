using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;
using System.Collections;

[CreateAssetMenu(fileName = "Spawn Action", menuName = "State Machines/Actions/Spawn")]
public class SpawnActionSO : StateActionSO<SpawnAction> { }

public class SpawnAction : StateAction
{
    private GameObject _gameObject;
    public override void Awake(StateMachine stateMachine)
	{
		_gameObject = stateMachine.gameObject;
	}

    public override void OnUpdate() { }

    public override void OnStateEnter()
    { 
        
    }
    public override void OnStateExit()
    {
        
    }
}
