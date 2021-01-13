using System.Collections.Generic;
using UnityEngine;

public class BasicMonsterData : MonsterData
{
    // Inherited
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _movespeed;
    [SerializeField] private float _armorValue;
    // controller data
    [SerializeField] private Transform[] _checkPoints = default;
    [HideInInspector] public Queue<Vector3> listCheckPoints;
    [HideInInspector] public Vector3 targetDestination;
    [HideInInspector] public Vector3 lastTargetDestination;
    [HideInInspector] public float distanceToTarget;
    [HideInInspector] public bool reachedTown = false;
    // Other fields
    private float _currentHP;

    public override float Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public override float MaxHP
    {
        get => _maxHP;
        set => _maxHP = value;
    }
    public override float Movespeed
    {
        get => _movespeed;
        set => _movespeed = value;
    }
    public override float ArmorValue
    {
        get => _armorValue;
        set => _armorValue = value;
    }

    public float CurrentHP
    {
        get => _currentHP;
        set => _currentHP = value;
    }

    private void Awake()
    {
        listCheckPoints = new Queue<Vector3>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _checkPoints.Length; i++)
        {
            listCheckPoints.Enqueue(_checkPoints[i].position);
        }
    }
}
