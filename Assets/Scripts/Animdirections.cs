using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animdirections : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            anim.SetInteger("ydir", 1);
            anim.SetInteger("xdir", 0);
        }
        else if(Input.GetKey(KeyCode.D)){
            anim.SetInteger("ydir", 0);
            anim.SetInteger("xdir", 1);
        }
        else if(Input.GetKey(KeyCode.A)){
            anim.SetInteger("ydir", 0);
            anim.SetInteger("xdir", -1);
        }
        else if(Input.GetKey(KeyCode.X)){
            anim.SetInteger("ydir", -1);
            anim.SetInteger("xdir", 0);
        }else{
            anim.SetInteger("ydir", 0);
            anim.SetInteger("xdir", 0);
        }
    }
}
