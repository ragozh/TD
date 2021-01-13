using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }
public class IntEventListener : MonoBehaviour
{
    [SerializeField] 
    private IntEventSO _event = default;

    public IntEvent ListenerRespondOnEventRaised;

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

    private void Respond(int param)
    {
        if (ListenerRespondOnEventRaised != null)
            ListenerRespondOnEventRaised.Invoke(param);
    }
}