using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVManager : MonoBehaviour
{
    public static TVManager instance;

    AudioSource source;

    public GameObject tv;
    public AudioClip changesound;
    public List<Material> basematerial;
    [Header("Adventure")]
    public AdventurePlayer advplayer;
    public Material advtexture;
    bool advsubbed = false;
    float timingadv = 0;
    public AudioClip advfirst;
    public AudioClip advloop;
    public AudioSource advsource;

    [Header("Shop")]
    public ShopManager shop;
    public Material shoptexture;
    bool shopsubbed = false;
    // Start is called before the first frame update

    [Header("TeleKebab")]
    public TeleKebabController tvkb;
    public Material tvkbtexture;
    bool tvkbsubbed = false;

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
        ChangeChannel(0);
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
                
                //acabar esto
                if(timingadv > advfirst.length) advsource.clip = advloop;
                advsource.Play();
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
            case 6:
                tv.GetComponent<Renderer>().material = tvkbtexture;
                tvkb.Activate();
                tvkbsubbed = true;
                break;

            case 0:
                tv.GetComponent<Renderer>().material = basematerial[0];
                break;

            case 10:
                tv.GetComponent<Renderer>().material = basematerial[1];
                break;    
                //lol
            default: break;
        }
    }

    void UnsubAll(){
        if(advsubbed){
            advsubbed = false;
            advplayer.DeActivate();
            advsource.Pause();
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
        if(tvkbsubbed){
            tvkbsubbed = false;
            tvkb.DeActivate();
        }
    }
}
