using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    
    public static Action WKeyPressed;
    public static Action AKeyPressed;
    public static Action XKeyPressed;
    public static Action DKeyPressed;

    public static Action JKeyPressed;
    public static Action KKeyPressed;
    
    public static Action UpKeyPressed;
    public static Action DownKeyPressed;
    public static Action LeftKeyPressed;
    public static Action RightKeyPressed;
    public static Action EnterKeyPressed;
    
    public static Action NoWAXDKeyPressed;


    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            WKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.A))
        {
            AKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.X))
        {
            XKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.D))
        {
            DKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.J))
        {
            JKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.K))
        {
            KKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            UpKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            DownKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RightKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            EnterKeyPressed?.Invoke();
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.D)))
        {
            NoWAXDKeyPressed?.Invoke();
        }
    }
}
