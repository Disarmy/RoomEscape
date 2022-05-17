using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public void DoorOpenFunc()
    {
        StartCoroutine(DoorOpen());
    }
    IEnumerator DoorOpen()
    {
        while (transform.rotation != Quaternion.Euler(0, 80, 0))
        {
            Quaternion openRotation = Quaternion.Euler(0, 80, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, 2 * Time.deltaTime);

            yield return new WaitForSeconds(0.05f);
        }
    }

}
