using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public float originalPosition;
    public float movement;
    public float delay;

    IEnumerator DoorOpenEvent()
    {
        var nowPosition = 0.0f;
        while (nowPosition < originalPosition)
        {
            left.Translate(Vector3.right * movement);
            right.Translate(Vector3.left * movement);
            nowPosition += movement;

            yield return new WaitForSeconds(delay);
        }
    }
    public void DoorOpenFunc()
    {
        StartCoroutine(DoorOpenEvent());
    }
}
