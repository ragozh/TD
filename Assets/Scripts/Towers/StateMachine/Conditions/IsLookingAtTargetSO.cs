using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "Is Looking At target Condition", menuName = "State Machines/Conditions/Tower/Looking At Target")]
public class IsLookingAtTargetSO : StateConditionSO<IsLookingAtTarget>
{
    [Tooltip("Offset angle to accept rotation")]
    public float angleTreshold = 5;
}

public class IsLookingAtTarget : Condition
{
    private BasicTowerData _data;
    private Transform _transform;
    private IsLookingAtTargetSO _originSO => (IsLookingAtTargetSO)base.ThisSO;
    public override void Awake(StateMachine stateMachine)
    {
        _data = stateMachine.GetComponent<BasicTowerData>();
        _transform = stateMachine.GetComponent<Transform>();
    }
    protected override bool Statement()
    {
        var fromVector = new Vector2(_transform.forward.x, _transform.forward.z);
        var toVector = new Vector2(
            _data._currentTargetMonster.transform.position.x - _transform.position.x,
            _data._currentTargetMonster.transform.position.z - _transform.position.z
        );
        return Mathf.Abs(Vector3.Angle(fromVector, toVector)) < _originSO.angleTreshold;
    }
}