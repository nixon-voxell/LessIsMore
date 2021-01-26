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
    if(GunMec.bulletCount >0)
    {
    horizontal = Input.GetAxis("Horizontal")*movementMultiplier;
    vertical = Input.GetAxis("Vertical")*movementMultiplier;
    rb.AddForce(new Vector3(0, vertical, 0));
    rb.AddForce(new Vector3(horizontal, 0, 0));
    }
    
    animator.SetFloat("speed", Mathf.Max(rb.velocity.magnitude, 1.0f));

    if (Input.GetKeyDown(KeyCode.Space))
    {
      // perform dash
    }

    // map boundaries
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "enemy")
    {
      //game over
      GunMec.bulletCount = 0;
    }
  }
}
