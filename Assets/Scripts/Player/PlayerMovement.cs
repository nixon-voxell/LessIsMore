using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Animator animator;
  public float movementMultiplier = 0.1f;
  public float dashForce = 100;
  [HideInInspector]
  public Rigidbody2D rb;
  // Start is called before the first frame update
  void Start() 
  {
    danger = false;
    rb = GetComponent<Rigidbody2D>();
  }
    
  bool infected = false;
  public static bool danger = false;
  // Update is called once per frame
  void Update()
  {
    if(GunMec.bulletCount > 0)
    {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector3 totalForce = new Vector3(horizontal, vertical, 0)*movementMultiplier;

      animator.SetFloat("speed", Mathf.Min(rb.velocity.magnitude, 1.0f));

      if (Input.GetKeyDown(KeyCode.Space)) totalForce *= dashForce;

      rb.AddForce(totalForce);
      animator.SetFloat("speed", rb.velocity.magnitude);

      // // how does this work wtf
      // if(Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 0f)
      // {
      //   SoundManager.PlaySE("walking");
      // }
      // //map boundaries
    }
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "enemy" && infected == false)
    {
      //game over
      GunMec.bulletCount = 0;
      infected = true;
      if(infected)zombieSM.ZplaySE("zombieBite");
    }
  }

  void OnTriggerEnter2D(Collider2D co)
  {
    if(co.gameObject.tag == "door")
    {
      danger = true;
    }
  }

}
