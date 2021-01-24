using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementMultiplier = 0.1f;
  [HideInInspector]
  public Rigidbody2D rb;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    rb.AddForce(new Vector3(0, Input.GetAxis("Vertical")*movementMultiplier, 0));
    rb.AddForce(new Vector3(Input.GetAxis("Horizontal")*movementMultiplier, 0, 0));
  }
}
