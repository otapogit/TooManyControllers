using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animbuttons : MonoBehaviour
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
        if(Input.GetKey(KeyCode.J)){
            anim.SetBool("BPressed", true);

        }else{
            anim.SetBool("BPressed", false);
        }

        if(Input.GetKey(KeyCode.K)){
            anim.SetBool("APressed", true);

        }else{
            anim.SetBool("APressed", false);
        }
    }
}
