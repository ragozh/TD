using UnityEngine;
using UnityEngine.AI;

public class TestMoving : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime;
    }
}