using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag != "enemy")Destroy(gameObject);
    
  }
}
