using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Tower/Attack Time elapsed")]
public class IsElapsedAttackTimeSO : StateConditionSO<IsElapsedAttackTime>
{
	public float timerLength = 1f;
    public void SetTimer(float value) => timerLength = value;
}

public class IsElapsedAttackTime : Condition
{
	private float _startTime;
	private IsElapsedAttackTimeSO _originSO => (IsElapsedAttackTimeSO)base.ThisSO;
    private TowerController _controller;
    public override void Awake(StateMachine stateMachine)
    {
        _controller = stateMachine.GetComponent<TowerController>();
    }
    public override void OnStateEnter()
	{
        Debug.Log("Enter " + Time.time);
        _originSO.SetTimer(_controller.GetAttackTime());
		_startTime = Time.time;
	}
    public override void OnStateExit()
	{        
        Debug.Log("Exit " + Time.time);
    }
	protected override bool Statement() => Time.time >= _startTime + _originSO.timerLength;
}
