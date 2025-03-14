using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChannel :  MonoBehaviour,Button
{

    public GameObject left, right, up, down;
    Animator anim;
    public int channel;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetSelected(){
        anim.SetBool("selected", true);
    }
    public void SetUnselected(){
        anim.SetBool("selected", false);
    }

    public void SetPressed(){
        anim.SetTrigger("pressed");
    }

    public ChangeChannel ChangeButton(int x, int y){
        //En verdad esto no hace la accion
        if(x > 0 ) return right.GetComponent<ChangeChannel>();
        else if(x < 0) return left.GetComponent<ChangeChannel>();
        else if(y > 0) return up.GetComponent<ChangeChannel>();
        else if(y < 0) return down.GetComponent<ChangeChannel>();
        else return this;
    }
    public  void ExecuteAction(){
        TVManager.instance.ChangeChannel(channel);
        return;
    }
}
