using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public int attack = 6;

    Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    public void dmganim(){
        anim.SetTrigger("dmg");
    }
}
