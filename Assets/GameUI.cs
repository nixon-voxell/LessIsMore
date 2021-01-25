using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
  public int bulletCount;
  public Image[] bullet;
  public KeyCode shoot = KeyCode.Mouse0;
  

  void Update()
  {
    for(int i=0; i < bullet.Length; i++)
    {
      if(i < bulletCount)bullet[i].enabled = true;
      else bullet[i].enabled = false;
    }

    if(Input.GetKeyDown(shoot))
      {
        bulletCount--;
      }
  }
}
