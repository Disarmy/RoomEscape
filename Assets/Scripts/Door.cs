using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public float speed;
    public bool isLocked = true;
    public bool isOpen = false;
    public float doorOpenAngle;
    public float doorCloseAngle;
    public GameObject key;

    public UnityEvent _event;
    public UnityEvent _openEvent;

    private AudioSource audio;
    public void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(key)
        {
            if (Vector3.Distance(transform.position, key.transform.position) <= 1.5f)
            {
                isLocked = false;
                key.transform.parent = null;
                Destroy(key);
                _openEvent.Invoke();
                StartCoroutine(DoorOpen());
                audio.Play();
                isOpen = true;
            }
        }
    }

    private void OnMouseDown()
    {
        StopAllCoroutines();
        if (!isLocked)
        {
            if (!isOpen)
            {
                StartCoroutine(DoorOpen());
                _openEvent.Invoke();
                audio.Play();
                isOpen = true;
            }
            else
            {
                StartCoroutine(DoorClose());
                audio.Play();
                isOpen = false;
            }
        }
        else
        {
            _event.Invoke();
        }
    }

    IEnumerator DoorOpen()
    {
        while (transform.rotation != Quaternion.Euler(0,doorOpenAngle, 0))
        {
            Quaternion openRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, speed * Time.deltaTime);

            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator DoorClose()
    {
        while (transform.rotation != Quaternion.Euler(0, doorCloseAngle, 0))
        {
            Quaternion closeRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, closeRotation, speed * Time.deltaTime);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
