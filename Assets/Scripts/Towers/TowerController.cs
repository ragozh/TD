using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private BasicTowerData _data = default;
    
    private CapsuleCollider _capsuleCollider;
    // Attack parameters
    private float _nextAttackTime = 0;
    private float _attackDelay;

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _data = GetComponent<BasicTowerData>();
    }

    private void OnEnable()
    {
        _capsuleCollider.radius = _data.AttackRange; // set range attack
    }

    private void Update()
    {
        FindCurrentTarget();
    }

    private void FindCurrentTarget()
    {
        if (_data._currentTargetMonster)    return;
        ClearList(_data._listMonsterInRange);
        if (_data._listMonsterInRange.Count == 0)   return;
        _data._currentTargetMonster = _data._listMonsterInRange[0];
    }
    public Transform GetCurrentTargetTransform()
    {
        return _data._currentTargetMonster.transform;
    }

    private void ClearList(List<BasicMonsterController> list)
    {
        var listToClean = new List<BasicMonsterController>();
        foreach (var element in list)
        {
            if (element == null)    listToClean.Add(element);
        }
        list.RemoveAll(x => listToClean.Contains(x));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var controller = other.GetComponent<BasicMonsterController>();
            if (!_data._listMonsterInRange.Contains(controller))
                _data._listMonsterInRange.Add(controller);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var controller = other.GetComponent<BasicMonsterController>();
            if (!_data._listMonsterInRange.Contains(controller))
                _data._listMonsterInRange.Add(controller);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var controller = other.GetComponent<BasicMonsterController>();
            if (_data._listMonsterInRange.Contains(controller))
                _data._listMonsterInRange.Remove(controller);
            if (_data._currentTargetMonster == controller)
                _data._currentTargetMonster = null;
        }
    }

    public void AttackAction()
    {
        _attackDelay = (float) 1 / _data.AttackSpeed;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        if (!ShouldAttack())
        {
            yield break; 
        }
        _nextAttackTime = Time.time + _attackDelay;

        yield return StartCoroutine(OnAttackStart());
        yield return StartCoroutine(OnAttackContinue());
        yield return StartCoroutine(OnAttackEnd());
    }

    private IEnumerator OnAttackStart()
    {
        yield return null;
    }

    private IEnumerator OnAttackContinue()
    {
        yield return StartCoroutine(DoAttack());
    }

    private IEnumerator OnAttackEnd()
    {
        yield return null;
    }
    private IEnumerator DoAttack()
    {
        Debug.Log("hit");
        yield return null;
    }
    public bool ShouldAttack()
    {
        return Time.time > _nextAttackTime;
    }
    public bool IsOnAttacking() => _data.isOnAttacking;
    public void SetAttacking() => _data.isOnAttacking = true;
    public void SetNotAttacking() => _data.isOnAttacking = false;
}
