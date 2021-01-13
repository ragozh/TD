using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector] public bool isMoving;
    private Camera _mainCamera;
    private Vector3 targetPosition;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        ClickToMove();
    }
    private void ClickToMove()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var worldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = worldPosition;
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isMoving = false;
        }
    }

    internal Vector3 GetTargetPosition()
    {
        return new Vector3(targetPosition.x, 0, targetPosition.z);
    }
}
