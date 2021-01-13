using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "In Town Action", menuName = "State Machines/Actions/In Town")]
public class ReachedTownActionSO : StateActionSO<ReachedTownAction> { }

public class ReachedTownAction : StateAction
{
    private GameObject _gameObject;
    private BasicMonsterController _controller;    
    private BasicMonsterData _data;
    public override void Awake(StateMachine stateMachine)
	{
		_gameObject = stateMachine.gameObject;
        _controller = stateMachine.GetComponent<BasicMonsterController>();
        _data = stateMachine.GetComponent<BasicMonsterData>();
	}
    public override void OnUpdate() { }
    public override void OnStateEnter()
    {
        _controller.DealDamage(_data.Damage);
        GameObject.Destroy(_gameObject);
    }
}