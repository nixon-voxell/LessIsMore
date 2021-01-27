using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{
  public GameObject prefab;
  void OnBecameInvisible()
  {
    Destroy(gameObject);
  }
}
