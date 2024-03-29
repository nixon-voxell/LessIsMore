using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Animator animator;
  public float movementMultiplier = 0.1f;
  public float dashForce = 100;

  [HideInInspector]
  public Rigidbody2D rb;
  public GameObject liftopen;
  public static bool infected = false;
  void Start() 
  {
    infected = false;
    danger = false;
    rb = GetComponent<Rigidbody2D>();
  }
  public static bool danger = false;
  // Update is called once per frame
  void FixedUpdate()
  {
    Cursor.visible = false;
    if(!infected)
    {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector3 totalForce = new Vector3(horizontal, vertical, 0)*movementMultiplier;

      animator.SetFloat("speed", Mathf.Min(rb.velocity.magnitude, 1.0f));

      if (Input.GetKeyDown(KeyCode.Space))
      {
        totalForce *= dashForce;
      }

      rb.AddForce(totalForce);
      animator.SetFloat("speed", rb.velocity.magnitude);

      // // how does this work wtf
      if(Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 0f)
      {
        PlayerSM.PlaySE("walking");
      }
    }
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "enemy" && infected == false)
    {
      //game over
      infected = true;
      danger = false;
      if(infected)zombieSM.ZplaySE("zombieBite");
    }
    if(col.gameObject.tag == "door")
    {
      liftopen.SetActive(true);
    }
  }

  void OnDisable()
  {
    Cursor.visible = true;
  }

}
