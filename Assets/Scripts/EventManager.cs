using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    
    public static Action WKeyPressed;
    public static Action WKeyDown;
    public static Action AKeyPressed;
    public static Action AKeyDown;
    public static Action XKeyPressed;
    public static Action XKeyDown;
    public static Action DKeyPressed;
    public static Action DKeyDown;

    public static Action JKeyPressed;
    public static Action JKeyDown;
    public static Action KKeyPressed;
    public static Action KKeyDown;
    
    public static Action UpKeyPressed;
    public static Action UpKeyDown;
    public static Action DownKeyPressed;
    public static Action DownKeyDown;
    public static Action LeftKeyPressed;
    public static Action LeftKeyDown;
    public static Action RightKeyPressed;
    public static Action RightKeyDown;
    public static Action EnterKeyPressed;
    public static Action EnterKeyDown;
    
    public static Action NoWaxdKeyPressed;


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
        else if (Input.GetKey(KeyCode.A))
        {
            AKeyPressed?.Invoke();
        }
        else if (Input.GetKey(KeyCode.X))
        {
            XKeyPressed?.Invoke();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            DKeyPressed?.Invoke();
        }
        else
        {
            NoWaxdKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            WKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            AKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            XKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DKeyDown?.Invoke();
        }

        if (Input.GetKey(KeyCode.J))
        {
            JKeyPressed?.Invoke();
        }
        if (Input.GetKey(KeyCode.K))
        {
            KKeyPressed?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            JKeyDown?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            KKeyDown?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpKeyPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownKeyPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftKeyPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightKeyPressed?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftKeyDown?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightKeyDown?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterKeyPressed?.Invoke();
        }
    }
}
