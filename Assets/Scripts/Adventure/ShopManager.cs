using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    public AdventurePlayer player;
    // Start is called before the first frame update


    void AddEnergy(){
        player.energy +=5;
        player.energy = Mathf.Min(player.energy,100);
        player.PrintEnergy();
    }

    void AddHp(){
        player.hp +=5;
        player.hp = Mathf.Min(player.hp,100);
        player.PrintHP();
    }

    public void Activate(){
        EventManager.JKeyDown += AddEnergy;
        EventManager.KKeyDown += AddHp;
    }

    public void DeActivate(){
        EventManager.JKeyDown -= AddEnergy;
        EventManager.KKeyDown -= AddHp;
    }
}
