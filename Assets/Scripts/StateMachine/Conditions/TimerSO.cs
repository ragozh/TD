using UnityEngine;
using TD.StateMachine;
using TD.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Time elapsed")]
public class TimerSO : StateConditionSO<Timer>
{
	public float timerLength = 1f;
    public void SetTimer(float value) => timerLength = value;
}

public class Timer : Condition
{
	private float _startTime;
	private TimerSO _originSO => (TimerSO)base.ThisSO; // The SO this Condition spawned from

	public override void OnStateEnter()
	{
		_startTime = Time.time;
	}
    public override void OnStateExit()
    {
    }
	protected override bool Statement() => Time.time >= _startTime + _originSO.timerLength;
}
