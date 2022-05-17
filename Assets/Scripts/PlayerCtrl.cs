using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;

    private Vector3 speed;
    private float forwardSpeed;
    private float sideSpeed;

    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    private float verticalVelocity = 0f;


    private CharacterController cc;
    private Flashlight_PRO flash;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        flash = GetComponentInChildren<Flashlight_PRO>();
    }

    void Update()
    {
        FPMove();
        FPRotate();

        if (Input.GetKeyDown(KeyCode.F))
        {
            flash.Switch();
        }
    }

    //Player�� x��, z�� �������� ���
    void FPMove()
    {
        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
    }

    void FPRotate()
    {
        //�¿� ȸ��
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //���� ȸ��
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
