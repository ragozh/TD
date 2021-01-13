using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Rotate Action", menuName = "State Machines/Actions/Tower/Rotate Action")]
public class RotateActionSO : StateActionSO<RotateAction> { }

public class RotateAction : StateAction
{
    private Transform _transform;
    private BasicTowerData _data;
    public override void Awake(StateMachine stateMachine)
    {
        _transform = stateMachine.GetComponent<Transform>();
        _data = stateMachine.GetComponent<BasicTowerData>();
    }
    public override void OnUpdate()
    {
        var target  = _data._currentTargetMonster.transform;
        _transform.LookAt(new Vector3(target.position.x, _transform.position.y, target.position.z));
    }

    public override void OnStateExit()
    {
    }
}