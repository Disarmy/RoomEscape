using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessEvent : ChessBoard
{
    public Transform ChessBoard;

    protected override void Update()
    {
        if(Vector3.Distance(transform.position, ChessBoard.position) < 1f)
        {
            Destroy(gameObject);
            _event.Invoke();
        }
    }
}
