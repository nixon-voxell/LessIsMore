using UnityEngine;

public class GunMec : MonoBehaviour
{
  public static int bulletCount = 6;
  public GameObject bulletPrefab;
  public GameObject cursor;
  public float bulletspeed;
  public Transform firepoint;
  public GameObject arm;
  public KeyCode shoot = KeyCode.Mouse0;
  
  public PlayerMovement movement;
  public ParticleSystem firingEffect;
  
  void Update()
  {
    // mouse point in world position
    Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // mouse point relative to player
    Vector2 mousePos = mouseWorldPos - new Vector2(transform.position.x, transform.position.y);

    float pointAngle = Mathf.Atan2(mousePos.y, mousePos.x)* Mathf.Rad2Deg;
    arm.transform.rotation = Quaternion.Euler(0, 0, pointAngle);
    cursor.transform.position = mouseWorldPos;

    // right0, up90, left180/-180, down-90;
    if(pointAngle >= 90 || pointAngle <= -90)
    {
      transform.eulerAngles = new Vector3(0, 180, 0);
      mousePos.x = -mousePos.x; //fix flipping bug
    }else
    {
      transform.eulerAngles = Vector3.zero;
    }
    // shooting
    if(Input.GetKeyDown(shoot) && bulletCount > 0 && !PlayerMovement.infected && PlayerMovement.danger)
    {
      PlayerSM.PlaySE("shooting");
      bulletCount--;

      GameObject bullets;
      bullets = Instantiate(bulletPrefab, firepoint.position, Quaternion.Euler(0, 0, pointAngle));
      Rigidbody2D bulletsRB = bullets.GetComponent<Rigidbody2D>();
      bulletsRB.velocity = transform.TransformDirection(mousePos.normalized)*bulletspeed;
      print("Shoot");
      //shooting effect
      Destroy(Instantiate(firingEffect, firepoint.position, Quaternion.identity),5f);
    }
  }
}