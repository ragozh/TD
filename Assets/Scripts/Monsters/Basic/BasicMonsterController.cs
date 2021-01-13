using UnityEngine;
using UnityEngine.Events;

public class BasicMonsterController : MonoBehaviour
{
    [SerializeField] private BasicMonsterData _monsterData;
    [SerializeField] private BoolEventSO _event = default;
    [SerializeField] private TownHPSO _townHP = default;
    public BoolEvent ListenerRespond;
    private void Awake()
    {
        _monsterData = GetComponent<BasicMonsterData>();
    }

    private void OnEnable()
    {
        if (_event != null)
            _event.OnEventRaised += RespondOnReachedTown;
    }

    private void OnDisable()
    {
        if (_event != null)
            _event.OnEventRaised -= RespondOnReachedTown;
    }
    public void RespondOnReachedTown(bool isReachedTown)
    {
        _monsterData.reachedTown = isReachedTown;
    }
    public void DealDamage(float amount)
    {
        _townHP.HP -= amount;
    }
}

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }
