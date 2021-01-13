using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    [SerializeField] private IntEventSO _event = default;
    [SerializeField] private int value = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse cliked, event raise, sent " + value);
            _event.RaiseEvent(value);
        }
    }
}
