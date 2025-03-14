using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            MoveUp();
        }else if(Input.GetKey(KeyCode.D)){
            MoveRight();
        }else if(Input.GetKey(KeyCode.X)){
            MoveDown();
        }else if(Input.GetKey(KeyCode.A)){
            MoveLeft();
        }else{
            rb.velocity = new Vector3(0,0,0);
        }
    }

    void MoveRight(){
        rb.velocity = new Vector3(1 * speed,0,0);
    }

    void MoveUp(){
        rb.velocity = new Vector3(0,1* speed,0);
    }

    void MoveDown(){
        rb.velocity = new Vector3(0,-1* speed,0);
    }

    void MoveLeft(){
        rb.velocity = new Vector3(-1* speed,0,0);
    }
}
