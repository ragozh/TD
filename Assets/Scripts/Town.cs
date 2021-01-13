using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField]
    private BoolEventSO _event = default;
    private void OnTriggerEnter(Collider other)
    {
        _event.RaiseEvent(true);
    }
}

