using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVManager : MonoBehaviour
{
    public static TVManager instance;

    AudioSource source;

    public GameObject tv;
    public AudioClip changesound;
    [Header("Adventure")]
    public AdventurePlayer advplayer;
    public Material advtexture;
    bool advsubbed = false;
    [Header("Shop")]
    public ShopManager shop;
    public Material shoptexture;
    bool shopsubbed = false;
    // Start is called before the first frame update

    [Header("Mierda")]
    public Material sadbabtex;
    public AudioClip kbabmusic;
    bool kbabsubbed = false;
    float timing = 0;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        ChangeChannel(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(kbabsubbed){
            timing += Time.deltaTime;
        }
    }


    public void ChangeChannel(int channel){
        UnsubAll();
        source.time = 0;
        source.PlayOneShot(changesound);
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

            case 7:
                tv.GetComponent<Renderer>().material = sadbabtex;
                kbabsubbed = true;
                source.clip = kbabmusic;
                source.time = timing;
                source.Play();
                break;
                //lol
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
       if(kbabsubbed){
            kbabsubbed = false;
            source.Stop();
            source.clip = null;

        }
    }
}
