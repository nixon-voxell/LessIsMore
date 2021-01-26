using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static AudioClip zombieBite, gunFire, morseEffect, walking;
  public static AudioClip  groan, zombieDie, stopwalk, click;
  static AudioSource audioScr;
    // Start is called before the first frame update
  void Start()
  {
    audioScr = GetComponent<AudioSource>();

    zombieBite = Resources.Load<AudioClip>("zombieBite");
    gunFire = Resources.Load<AudioClip>("shooting");
    morseEffect = Resources.Load<AudioClip>("morsecode");
    walking= Resources.Load<AudioClip>("walking");
    groan= Resources.Load<AudioClip>("zombieGroan");
    zombieDie = Resources.Load<AudioClip>("zombieDie");
    click = Resources.Load<AudioClip>("click");
  }

  public static void PlaySE(string clip)
  {
    switch(clip)
    {
      case "zombieBite":
        audioScr.PlayOneShot(zombieBite);
        break;
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
      case "zombieGroan":
        audioScr.PlayOneShot(groan);
        break;
      case "zombieDie":
        audioScr.PlayOneShot(zombieDie);
        break;
        case "click":
        audioScr.PlayOneShot(click);
        break;
    }
  }
    public void ClickSE()
  {
    SoundManager.PlaySE("click");
  }
}
