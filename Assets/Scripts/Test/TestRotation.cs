using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    [SerializeField] Transform target = default;
    void Update()
    {
        if (!target)    return;
        // var newRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        // newRotation.x = 0.0f;
        // newRotation.z = 0.0f;
        // transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1);

        
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
}
