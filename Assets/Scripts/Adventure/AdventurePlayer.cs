using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdventurePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EventManager.WKeyPressed += MoveUp();
        EventManager.AKeyPressed += MoveLeft();
        EventManager.DKeyPressed += MoveRight();
        EventManager.XKeyPressed += MoveDown();    
        //EventManager.NoWaxdKeyPressed += MoveNone();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    Action MoveRight(){

        rb.velocity = new Vector3(1 * speed,0,0);
        return null;    
    }

    Action MoveUp(){
        rb.velocity = new Vector3(0,1* speed,0);
        return null;
    }

    Action MoveDown(){
        Debug.Log("Hellou");
        rb.velocity = new Vector3(0,-1* speed,0);
        return null;
    }

    Action MoveLeft(){
        rb.velocity = new Vector3(-1* speed,0,0);
        return null;
    }
    
    Action MoveNone(){
        rb.velocity = new Vector3(0,0,0);
        return null;
    }
}
