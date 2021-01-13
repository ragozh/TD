using System;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] 
    private VoidEventSO _event = default;

    public UnityEvent ListenerRespondOnEventRaised;

    private void OnEnable()
    {
        if (_event != null)
            _event.OnEventRaised += Respond;
    }

    private void OnDisable()
    {
        if (_event != null)
            _event.OnEventRaised -= Respond;
    }

    private void Respond()
    {
        if (ListenerRespondOnEventRaised != null)
            ListenerRespondOnEventRaised.Invoke();
    }
}
