using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSM : MonoBehaviour
{
  public static AudioClip  groan, zombieBite, zombieDie;
  static AudioSource audioScr;

  void Start()
  {
    audioScr = GetComponent<AudioSource>();
    
    zombieBite = Resources.Load<AudioClip>("zombieBite");
    groan = Resources.Load<AudioClip>("zombieGroan");
    zombieDie = Resources.Load<AudioClip>("zombieDie");
  }
  public static void ZplaySE(string clip)
  {
    switch(clip)
    {
      case "zombieBite":
        audioScr.PlayOneShot(zombieBite);
        break;
      case "zombieGroan":
        audioScr.clip = groan;
        audioScr.Play();
        break;
      case "zombieDie":
        audioScr.PlayOneShot(zombieDie);
        break;
    }
  }
}

