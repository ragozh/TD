using System;
using UnityEngine;

namespace TD.StateMachine.ScriptableObjects
{
	[CreateAssetMenu(fileName = "New Transition", menuName = "State Machines/Transition")]
    public class StateTransitionSO : ScriptableObject
    {
        [SerializeField] private TransitionItem _transitionItem = default;
		internal TransitionItem GetTransitionItem()
		{
			return _transitionItem;
		}
    }
}