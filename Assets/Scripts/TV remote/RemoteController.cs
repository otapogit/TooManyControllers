using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public ChangeChannel startbutton;
    ChangeChannel selectedButton;

    bool cond = false;

    void Start()
    {
        selectedButton =startbutton;
        selectedButton.SetSelected();
        Activate();
    }

    void UpChannel(){
            selectedButton.SetUnselected();
            selectedButton = selectedButton.ChangeButton(0,1);
            selectedButton.SetSelected();
    }

        void DownChannel(){
            selectedButton.SetUnselected();
            selectedButton = selectedButton.ChangeButton(0,-1);
            selectedButton.SetSelected();
    }
        void RightChannel(){
            selectedButton.SetUnselected();
            selectedButton = selectedButton.ChangeButton(1,0);
            selectedButton.SetSelected();
    }
        void LeftChannel(){
            selectedButton.SetUnselected();
            selectedButton = selectedButton.ChangeButton(-1,0);
            selectedButton.SetSelected();
    }

    void ExecuteAction(){
        selectedButton.ExecuteAction();
    }
 
    void Activate(){
        EventManager.UpKeyDown += UpChannel;
        EventManager.DownKeyDown += DownChannel;
        EventManager.RightKeyDown += RightChannel;
        EventManager.LeftKeyDown += LeftChannel;
        EventManager.EnterKeyPressed += ExecuteAction;
    }
    void DeActivate(){
        EventManager.UpKeyDown -= UpChannel;
        EventManager.DownKeyDown -= DownChannel;
        EventManager.RightKeyDown -= RightChannel;
        EventManager.LeftKeyDown -= LeftChannel;
        EventManager.EnterKeyPressed -= ExecuteAction;
    }
}
