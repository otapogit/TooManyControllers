using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVManager : MonoBehaviour
{
    public static TVManager instance;


    public GameObject tv;
    [Header("Adventure")]
    public AdventurePlayer advplayer;
    public Material advtexture;
    bool advsubbed = false;
    [Header("Shop")]
    public ShopManager shop;
    public Material shoptexture;
    bool shopsubbed = false;
    // Start is called before the first frame update

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        ChangeChannel(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)){
            ChangeChannel(1);
        }else if(Input.GetKeyDown(KeyCode.B)){
            ChangeChannel(2);
        }
    }


    public void ChangeChannel(int channel){
        UnsubAll();
        switch(channel){
            case 1: 
            advplayer.Activate();
            tv.GetComponent<Renderer>().material = advtexture;
            advsubbed = true;
            break;
            case 2:
            shop.Activate();
            tv.GetComponent<Renderer>().material = shoptexture;
            shopsubbed = true;
            break;
            default: break;
        }
    }

    void UnsubAll(){
        if(advsubbed){
            advsubbed = false;
            advplayer.DeActivate();
        }
        if(shopsubbed){
            shopsubbed = false;
            shop.DeActivate();
        }
    }
}
