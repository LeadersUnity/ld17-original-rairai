using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSEbg : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip bgmClip;

    public AudioSource SESource;
    public AudioClip SEfire;
    public AudioClip SEgard;
    public AudioClip SEdamage;
    public AudioClip SEheal;
   
    void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }
    public void fireSE()
    {
        SESource.PlayOneShot(SEfire);
    }
     public void gardSE()
    {
        SESource.PlayOneShot(SEgard);
    }
     public void healSE()
    {
        SESource.PlayOneShot(SEheal);
    }
    public void damageSE()
    {
        SESource.PlayOneShot(SEdamage);
    }

  
}   
