using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCam : MonoBehaviour
{
  public Camera cam;
  public float realCamSize = 15f;
  public Vector3 offset;
  public Transform player;
  public float camspeed = 0.125f;
  // public Vector3 mapPos;

  public float delayTime = 2.0f;
  private float timePassed;


  void Start()
  {
    // transform.position = mapPos;
    timePassed = 0.0f;
  }
  void Update()
  {
    timePassed += Time.deltaTime;
    if (timePassed >= delayTime) PlayerFollow();
  }

  void PlayerFollow()
  {
    Vector3 desiredPos = player.position + offset;
    Vector3 smoothcam = Vector3.Lerp(transform.position, desiredPos, camspeed);
    transform.position = smoothcam;

    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, realCamSize, 0.1f);
  }
}
