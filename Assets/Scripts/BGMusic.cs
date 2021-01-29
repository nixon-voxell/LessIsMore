using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
  public AudioSource audioSource;

  public AudioClip startBGMusic;
  public AudioClip gameBGMusic;

  void Awake() => DontDestroyOnLoad(this.gameObject);

  void Start()
  {
    audioSource.clip = startBGMusic;
    audioSource.loop = false;
    audioSource.Play();
  }

  void Update()
  {
    if (!audioSource.isPlaying)
    {
      audioSource.clip = gameBGMusic;
      audioSource.loop = true;
      audioSource.Play();
    }
  }
}
