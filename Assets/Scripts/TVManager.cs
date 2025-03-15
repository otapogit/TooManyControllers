using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

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
    bool inloop = false;


    [Header("Shop")]
    public ShopManager shop;
    public Material shoptexture;
    bool shopsubbed = false;
    // Start is called before the first frame update

    [Header("TeleKebab")]
    public TeleKebabController tvkb;
    public Material tvkbtexture;
    public AudioClip tvkbmusic;
    bool tvkbsubbed = false;
    float timingtvkb = 0;

    [Header("Mierda")]
    public Material sadbabtex;
    public AudioClip kbabmusic;
    bool kbabsubbed = false;
    float timing = 0;

    [Header("Slider")]
    public Slider slider;
    float volume = 0.7f;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        ChangeChannel(0);
        advsource.Play();
        advsource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(kbabsubbed){
            timing += Time.deltaTime;
        }
        if(advsubbed || shopsubbed){
            timingadv += Time.deltaTime;
            if(!inloop && timingadv > advfirst.length) {
                advsource.clip = advloop;
                inloop = true;
                advsource.Play();
            }
        }
        if(tvkbsubbed){
            timingtvkb += Time.deltaTime;
        }
    }


    public void ChangeChannel(int channel){

        if(channel != 13 && channel != 14){
        UnsubAll();
        source.time = 0;
        source.PlayOneShot(changesound);
        }
        switch(channel){
            case 1: 
                advplayer.Activate();
                tv.GetComponent<Renderer>().material = advtexture;
                advsubbed = true;
            
                advsource.UnPause();
                
                break;
            case 2:
                shop.Activate();
                tv.GetComponent<Renderer>().material = shoptexture;
                shopsubbed = true;
                            
                advsource.UnPause();
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
                source.clip = tvkbmusic;
                source.time = timingtvkb;
                source.Play();
                break;

            /*case 0:
                tv.GetComponent<Renderer>().material = basematerial[0];
                break;
            */
            case 10:
                tv.GetComponent<Renderer>().material = basematerial[1];
                break;    
                //lol

            case 13:
            //up
            volume += 0.05f;
            volume = Mathf.Max(Mathf.Min(1.0f,volume),0.0f);
            SetVolume(volume);
            break;
            case 14:
            //down
            volume -= 0.05f;
            volume = Mathf.Max(Mathf.Min(1.0f,volume),0.0f);
            SetVolume(volume);
            break;

            case 100:
                Application.Quit();
                break;
            default: 
            tv.GetComponent<Renderer>().material = basematerial[2];
            break;
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
            advsource.Pause();
        }
       if(kbabsubbed){
            kbabsubbed = false;
            source.Stop();
            source.clip = null;

        }
        if(tvkbsubbed){
            tvkbsubbed = false;
            tvkb.DeActivate();
            source.Stop();
            source.clip = null;
        }
    }

    void SetVolume(float vol){
        advsource.volume = vol;
        source.volume = vol;
        slider.value = vol;
    }

    public void StopAll(){
        advsource.Stop();
        source.Stop();
    }
}
