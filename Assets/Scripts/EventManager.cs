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
        if (Input.GetKeyDown(KeyCode.W))
        {
            WKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            XKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            JKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            KKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterKeyPressed?.Invoke();
        }
    }
}
