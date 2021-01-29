using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  public Rigidbody2D rb;
  public Transform player;
  public float movespeed;
  public GameUI UI;
  public GameObject bloodEffect;

  public Animator animator;

  void Start()
  {
    UI.zombieCount++;
    rb = gameObject.GetComponent<Rigidbody2D>();
  }
  void FixedUpdate()
  {
    //distance between player and ememy
    Vector3 direction = player.position - transform.position;
    
    // convert coords to angle against player
    // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    direction.Normalize(); //direction of enemy to player

    if(PlayerMovement.danger)
    {
      rb.MovePosition(transform.position + (direction* movespeed* Time.deltaTime));
      animator.SetBool("Move", true);

      zombieSM.ZplaySE("zombieGroan");
      if(direction.x > 0) // left
      {
        transform.eulerAngles = new Vector3(0, 180, 0);
      }else transform.eulerAngles = Vector3.zero;

      //zombies goes crazy when bulletCount is zero
      if(GunMec.bulletCount < 0)
      {
        movespeed = 40;
      }
    } else animator.SetBool("Move", false);

  }
  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "bullet")
    {
      UI.zombieCount--;
      zombieSM.ZplaySE("zombieDie");
      Destroy(gameObject);
      // die animation

      // Blood Effect
      Destroy(Instantiate(bloodEffect, transform.position, Quaternion.Euler(-90.0f, 0, 0)), 10.0f);
    }
  }
}
