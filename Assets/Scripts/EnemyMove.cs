using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  public Rigidbody2D rd;
  public Transform player;
  Vector2 movement;
  public float movespeed;
  public float dimension;
  void Start()
  {
    GameUI.zombieCount ++;
    rd = gameObject.GetComponent<Rigidbody2D>();
    // float spot = Random.Range(-dimension, dimension);
    // transform.position = new Vector3(spot, spot, 0);
  }
  void Update()
  {
    //distance between player and ememy
    Vector3 direction = player.position - transform.position;
    
    // convert coords to angle against player
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    direction.Normalize(); //direction of enemy to player

    if(PlayerMovement.danger)
    {
      rd.MovePosition(transform.position + (direction* movespeed* Time.deltaTime));

      zombieSM.ZplaySE("zombieGroan");
      if(direction.x <0) // left
      {
        transform.eulerAngles = new Vector3(0, 180, 0);
      }else transform.eulerAngles = Vector3.zero;

      //zombies goes crazy when bulletCount is zero
      if(GunMec.bulletCount < 0)
      {
        movespeed = 40;
      }
    }

  }
  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.gameObject.tag == "bullet")
    {
      GameUI.zombieCount--;
      zombieSM.ZplaySE("zombieDie");
      Destroy(gameObject);
      // die animation
    }
  }
}
