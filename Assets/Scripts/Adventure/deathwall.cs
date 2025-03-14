using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathwall : MonoBehaviour
{
    public AdventurePlayer player;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            player.lose();
        }
    }
}
