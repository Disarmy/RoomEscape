using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChessBoard : MonoBehaviour
{
    public UnityEvent _event;
    public int count = 0;

    protected virtual void Update() {
        if(count == 4)
        {
            _event.Invoke();
        }
    }

    public void CountPlus()
    {
        count++;
    }
}
