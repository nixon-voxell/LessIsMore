using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM : MonoBehaviour
{
  public static AudioClip  click, gunFire, morseEffect, walking;
  
  static AudioSource audioScr;
    // Start is called before the first frame update
  void Start()
  {
    audioScr = GetComponent<AudioSource>();
    
    gunFire = Resources.Load<AudioClip>("shooting");
    morseEffect = Resources.Load<AudioClip>("morsecode");
    walking= Resources.Load<AudioClip>("walking");
    click = Resources.Load<AudioClip>("click");
  }

  public static void PlaySE(string clip)
  {
    switch(clip)
    {
      case "shooting":
        audioScr.PlayOneShot(gunFire);
        break;
      case "morsecode":
        audioScr.PlayOneShot(morseEffect);
        break;
      case "walking":
        audioScr.clip = walking;
        audioScr.Play();
        break;
      case "click":
        audioScr.PlayOneShot(click);
        break;
    }
  }
    public void ClickSE()
  {
    PlayerSM.PlaySE("click");
  }
    public void MorseSE()
  {
    PlayerSM.PlaySE("morsecode");
  }
}