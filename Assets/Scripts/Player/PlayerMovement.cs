using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Animator animator;
  public float movementMultiplier = 0.1f;
  public float dashForce = 100;

  public SpriteRenderer dashSpriteRenderer;
  [HideInInspector]
  public Material dashMaterial;
  public AnimationCurve dashEffectCurve;
  public float dashEffectDuration = 1.0f;
  private bool dashEffectInitiated;
  private float dashEffectTime;

  [HideInInspector]
  public Rigidbody2D rb;
  public GameObject liftopen;
  public static bool infected = false;
  void Start() 
  {
    danger = false;
    rb = GetComponent<Rigidbody2D>();
    dashMaterial = dashSpriteRenderer.material;
    dashMaterial.SetFloat("_Reveal", 0.0f);
  }
  public static bool danger = false;
  // Update is called once per frame
  void Update()
  {
    if (dashEffectInitiated)
    {
      if (dashEffectTime >= dashEffectDuration)
      {
        dashMaterial.SetFloat("_Reveal", 1.0f);
        dashEffectInitiated = false;
      }
      else dashMaterial.SetFloat("_Reveal", dashEffectCurve.Evaluate(dashEffectTime));
      dashEffectTime += Time.deltaTime;
    }
    if(GunMec.bulletCount > 0)
    {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector3 totalForce = new Vector3(horizontal, vertical, 0)*movementMultiplier;

      animator.SetFloat("speed", Mathf.Min(rb.velocity.magnitude, 1.0f));

      if (Input.GetKeyDown(KeyCode.Space))
      {
        totalForce *= dashForce;
        dashEffectInitiated = true;
      }

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
      infected = true;
      danger = false;
      if(infected)zombieSM.ZplaySE("zombieBite");
    }
    if(col.gameObject.tag == "door")
    {
      liftopen.SetActive(true);
    }

  }

}
