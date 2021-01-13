﻿using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Bool Event")]
public class BoolEventSO : ScriptableObject
{
    public UnityAction<bool> OnEventRaised;
    public void RaiseEvent(bool param)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(param);
    }
}