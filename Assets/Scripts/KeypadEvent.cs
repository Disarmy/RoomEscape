using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypadEvent : MonoBehaviour
{
    public ArrayList password;
    public UnityEvent _success;
    public UnityEvent _fail;

    public void Start()
    {
        password = new ArrayList(4);
    }

    public void PressSubmit()
    {
        if(password.Count == 4)
        {
            if(password[0].Equals(4) && password[1].Equals(7) && 
               password[2].Equals(1) && password[3].Equals(8))
            {
                _success.Invoke();
            }
            else
            {
                password.Clear();
                _fail.Invoke();
            }
        }
        else
        {
            password.Clear();
            _fail.Invoke();
        }
    }

    public void PressOne()
    {
        password.Add(1);
    }
    public void PressTwo()
    {
        password.Add(2);
    }
    public void PressThree()
    {
        password.Add(3);
    }
    public void PressFour()
    {
        password.Add(4);
    }
    public void PressFive()
    {
        password.Add(5);
    }
    public void PressSix()
    {
        password.Add(6);
    }
    public void PressSeven()
    {
        password.Add(7);
    }
    public void PressEight()
    {
        password.Add(8);
    }
    public void PressNine()
    {
        password.Add(9);
    }
    public void PressZero()
    {
        password.Add(0);
    }
}
