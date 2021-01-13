﻿using System.Collections.Generic;
using UnityEngine;

public class BasicTowerData : TowerData
{
    // Inherited
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRange;
    public override float AttackDamage
    {
        get => _attackDamage;
        set => _attackDamage = value;
    }
    public override float AttackSpeed
    {
        get => _attackSpeed;
        set => _attackSpeed = value;
    }
    public override float AttackRange
    {
        get => _attackRange;
        set => _attackRange = value;
    }

    // Controller
    public List<BasicMonsterController> _listMonsterInRange;
    public BasicMonsterController _currentTargetMonster;
    public bool isOnAttacking;
    // TODO: use abstract MonsterController instead of BasicMonsterController?
}