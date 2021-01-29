using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCam : MonoBehaviour
{
  public Camera cam;
  public float MapcameraSize;
  public float realCamSize = 15f;
  public Vector3 offset;
  public Transform player;
  public float camspeed = 0.125f;
  public Vector3 mapPos;
  void Start()
  {
    cam.orthographicSize = MapcameraSize;
    transform.position = mapPos;
  }
  void FixedUpdate()
  {
    Invoke("PlayerFollow",2f);
    cam.orthographicSize = Mathf.Lerp(MapcameraSize,realCamSize,0.1f);
  }

  void PlayerFollow()
  {
    Vector3 desiredPos = player.position + offset;
    Vector3 smoothcam = Vector3.Lerp(transform.position, desiredPos, camspeed);
    transform.position = smoothcam;
  }
}
