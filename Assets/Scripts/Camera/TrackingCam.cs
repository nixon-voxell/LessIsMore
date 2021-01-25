using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCam : MonoBehaviour
{
  public Vector3 offset;
  public Transform player;
  public float camspeed = 0.125f;
  void FixedUpdate()
  {
    Vector3 desiredPos = player.position + offset;
    Vector3 smoothcam = Vector3.Lerp(transform.position, desiredPos, camspeed);
    transform.position = smoothcam;
  }
}
