using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
  public GameObject gameoverUI;
  public Image[] bullet;
  public TextMeshProUGUI levelText;
  
  public int level = 1;

  void Update()
  {
    levelText.text = $"LEVEL :  {level}";
    for(int i=0; i < bullet.Length; i++)
    {
      if(i < GunMec.bulletCount)bullet[i].enabled = true;
      else bullet[i].enabled = false;
    }

    if(GunMec.bulletCount ==0)
    {
      gameoverUI.SetActive(true);
    }

    
  }
}
