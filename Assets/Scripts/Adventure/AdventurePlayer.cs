using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class AdventurePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    Animator anim;
    Enemy attacker;
    // Start is called before the first frame update

    public ShopManager sp;

    public int hp = 100;
    public int attack = 1;
    public float energy = 100;

    public List<TMP_Text> energytext;
    public List<TMP_Text> hptext;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attacker = null;
    }

    void Attack(){
        if(attacker != null){
            this.hp -= attacker.attack;
            HpDown();
            attacker.hp -= this.attack;
            attacker.dmganim();
            if(attacker.hp <= 0) {Destroy(attacker.gameObject);}
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        EventManager.KKeyDown += Attack;
        attacker = other.gameObject.GetComponent<Enemy>();
    }

    void OnTriggerExit2D(Collider2D other){
        EventManager.KKeyDown -= Attack;
        attacker = null;
    }


    void MoveRight(){
        anim.SetInteger("x",1);
        anim.SetInteger("y",0);
        rb.velocity = new Vector3(1 * speed,0,0);
        EnergyDown(); 

    }

    void MoveUp(){
        anim.SetInteger("x",0);
        anim.SetInteger("y",1);        
        rb.velocity = new Vector3(0,1* speed,0);
        EnergyDown();
}

    void MoveDown(){
        anim.SetInteger("x",0);
        anim.SetInteger("y",-1);
        rb.velocity = new Vector3(0,-1* speed,0);
        EnergyDown();

    }

    void MoveLeft(){
        anim.SetInteger("x",-1);
        anim.SetInteger("y",0);
        rb.velocity = new Vector3(-1* speed,0,0);
        EnergyDown();

    }
    
    void MoveNone(){
        anim.SetInteger("x",0);
        anim.SetInteger("y",0);
        rb.velocity = new Vector3(0,0,0);

    }

    void EnergyDown(){
        energy -= 0.05f;
        PrintEnergy();
        if(energy <= 0) lose();
    }

    void HpDown(){
        PrintHP();
        if(hp <=0)lose();
    }

    public void PrintHP(){
        foreach(TMP_Text t in hptext){
            t.text = hp.ToString();
        }
    }

    public void PrintEnergy(){
        foreach(TMP_Text t in energytext){
            t.text = (Mathf.Round(energy * 10.0f) * 0.1f).ToString();
        }
    }

    public void lose(){
        DeActivate();
        sp.DeActivate();
        SceneManager.LoadScene("SplashScene");
    }

    public void Activate(){
        
        EventManager.WKeyPressed += MoveUp;
        EventManager.AKeyPressed += MoveLeft;
        EventManager.DKeyPressed += MoveRight;
        EventManager.XKeyPressed += MoveDown;    
        EventManager.NoWaxdKeyPressed += MoveNone; 
    }

    public void DeActivate(){
        EventManager.WKeyPressed -= MoveUp;
        EventManager.AKeyPressed -= MoveLeft;
        EventManager.DKeyPressed -= MoveRight;
        EventManager.XKeyPressed -= MoveDown;    
        EventManager.NoWaxdKeyPressed -= MoveNone; 
    }


}
