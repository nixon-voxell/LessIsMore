using UnityEngine;

public class GunMec : MonoBehaviour
{
  public static int bulletCount = 6;
  public Rigidbody2D bulletPrefab;
  public GameObject cursor;
  public float bulletspeed;
  public Transform firepoint;
  public GameObject arm;
  public KeyCode shoot = KeyCode.Mouse0;
  public PlayerMovement movement;
  void Update()
  {
    // moving hand based on mouse
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

    float pointAngle = Mathf.Atan2(mousePos.y, mousePos.x)* Mathf.Rad2Deg;
    arm.transform.rotation = Quaternion.Euler(0, 0, pointAngle);

    // if(arm.transform.eulerAngles.z >= -80 && arm.transform.eulerAngles.z <= 80)
    // {
      
    // }

    // shooting
    if(Input.GetKeyDown(shoot))
    {
      // arm.transform.eulerAngles += new Vector3(0, 0, 30);
      bulletCount--;
      if(bulletCount > 0)
      {
        Rigidbody2D bullets;
        bullets = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
        bullets.velocity = transform.TransformDirection(mousePos*bulletspeed);
      }
    }

    if(movement.horizontal < 0)
    {
      arm.transform.eulerAngles = new Vector3(0, -180, 0);
      transform.eulerAngles = new Vector3(0, -180, 0);
    }else
    {
      transform.eulerAngles = Vector3.zero;
    }

  }
}