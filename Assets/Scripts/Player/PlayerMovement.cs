using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public GameObject hand;
  public CharacterController character;
  public Animator animator;
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
    float horizontal = Input.GetAxis("Horizontal")*movementMultiplier;
    float vertical = Input.GetAxis("Vertical")*movementMultiplier;
    rb.AddForce(new Vector3(0, vertical, 0));
    rb.AddForce(new Vector3(horizontal, 0, 0));
    
    if(horizontal != 0)
    {
      animator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    else if(vertical != 0)
    {
      animator.SetFloat("speed", Mathf.Abs(vertical));
    }

    if(horizontal < 0)
    {
      hand.transform.eulerAngles = new Vector3(0, -180, 0);
      transform.eulerAngles = new Vector3(0, -180, 0);
    }else
    {
      transform.eulerAngles = Vector3.zero;
      hand.transform.eulerAngles = Vector3.zero;
    }
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    float pointAngle = Mathf.Atan2(mousePos.y, mousePos.x)* Mathf.Rad2Deg;
    if(hand.transform.eulerAngles.z >= -80 && hand.transform.eulerAngles.z <= 80)
    {
      hand.transform.rotation = Quaternion.Euler(0, 0, pointAngle);

    }
  }  
}
