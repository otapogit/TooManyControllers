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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){

            selectedButton.SetUnselected();
            cond = true;
            selectedButton = selectedButton.ChangeButton(0,1);
            selectedButton.SetSelected();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
            selectedButton.SetUnselected();
            cond = true;
            selectedButton = selectedButton.ChangeButton(0,-1);
            selectedButton.SetSelected();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            selectedButton.SetUnselected();
            cond = true;
            selectedButton = selectedButton.ChangeButton(1,0);
            selectedButton.SetSelected();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            selectedButton.SetUnselected();
            cond = true;
            selectedButton = selectedButton.ChangeButton(-1,0);
            selectedButton.SetSelected();
        }

        if(!cond) return;

        if(Input.GetKeyDown(KeyCode.Return)){
            selectedButton.SetPressed();
        }

        selectedButton.ExecuteAction();
    }   
}
