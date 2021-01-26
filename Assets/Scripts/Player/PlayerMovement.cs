using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [HideInInspector]
  public float horizontal;
  [HideInInspector]
  public float vertical;
  public Animator animator;
  public float movementMultiplier = 0.1f;
  [HideInInspector]
  public Rigidbody2D rb;
  // Start is called before the first frame update
  void Start() => rb = GetComponent<Rigidbody2D>();

  // Update is called once per frame
  void Update()
  {
    horizontal = Input.GetAxis("Horizontal")*movementMultiplier;
    vertical = Input.GetAxis("Vertical")*movementMultiplier;
    rb.AddForce(new Vector3(0, vertical, 0));
    rb.AddForce(new Vector3(horizontal, 0, 0));
    
    animator.SetFloat("speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

    //contact with zombies 
    // map boundaries
  }  
}
