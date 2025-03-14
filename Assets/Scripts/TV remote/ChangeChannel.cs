using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChannel :  MonoBehaviour,Button
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject left, right, up, down = null;

    public  Button ChangeButton(int x, int y){
        //En verdad esto no hace la accion
        if(right != null||x > 0 ) return right.GetComponent<Button>();
        else if(left != null||x < 0) return left.GetComponent<Button>();
        else if(up != null||y > 0) return up.GetComponent<Button>();
        else if(down != null||y < 0) return down.GetComponent<Button>();
        else return this;
    }
    public  void ExecuteAction(){
        return;
    }
}
