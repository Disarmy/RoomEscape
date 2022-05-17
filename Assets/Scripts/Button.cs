using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent _event;
    private void OnMouseDown()
    {
        _event.Invoke();
    }
}
