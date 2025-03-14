using System;
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

        if (Input.GetKeyDown(KeyCode.J))
        {
            JKeyPressed?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            KKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            UpKeyPressed?.Invoke();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            DownKeyPressed?.Invoke();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftKeyPressed?.Invoke();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RightKeyPressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            EnterKeyPressed?.Invoke();
        }
    }
}
