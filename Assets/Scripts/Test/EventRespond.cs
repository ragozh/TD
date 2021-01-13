using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRespond : MonoBehaviour
{
    public void GetParam(int value)
    {
        Debug.Log("got the event " + value);
    }
}
