using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Rotate Action", menuName = "State Machines/Actions/Tower/Rotate Action")]
public class RotateActionSO : StateActionSO<RotateAction> { }

public class RotateAction : StateAction
{
    private Transform _transform;
    private TowerController _controller;
    public override void Awake(StateMachine stateMachine)
    {
        _transform = stateMachine.GetComponent<Transform>();
        _controller = stateMachine.GetComponent<TowerController>();
    }
    public override void OnUpdate()
    {
        var targetTransform  = _controller.GetCurrentTargetTransform();
        _transform.LookAt(new Vector3(targetTransform.position.x, _transform.position.y, targetTransform.position.z));
    }

    public override void OnStateExit()
    {
    }
}