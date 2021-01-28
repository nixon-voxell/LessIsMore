using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
  public GameObject lift;
  public GameObject liftText;
  public  int zombieCount;
  public GameObject levelUp;
  public GameObject gameoverUI;
  public Image[] bullet;
  public TextMeshProUGUI levelText;
  KeyCode uplevel = KeyCode.F;
  KeyCode OpenLift = KeyCode.Mouse1;
  public int level = 1;
  
  void Start() 
  {
    levelUp.SetActive(false);
    gameoverUI.SetActive(false);
  } 
  void Update()
  {
    levelText.text = $"LEVEL :  {level}";
    for(int i=0; i < bullet.Length; i++)
    {
      if(i < GunMec.bulletCount)bullet[i].enabled = true;
      else bullet[i].enabled = false;
    }

    if(GunMec.bulletCount == 0 || PlayerMovement.infected)
    {
      gameoverUI.SetActive(true);
    }
    
    if(zombieCount == 0)
    {
      levelUp.SetActive(true);
    }

    if(Input.GetKeyDown(uplevel))
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    if(Input.GetKeyDown(OpenLift))
    {
      PlayerSM.PlaySE("door");
      PlayerMovement.danger = true;
      lift.SetActive(false);
      liftText.SetActive(false);
    }
  }
  
}
