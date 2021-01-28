using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
  public void replay() // load level 1
  {
    SceneManager.LoadScene("Movement");
    GunMec.bulletCount = 6;
    PlayerMovement.infected = false;
    PlayerMovement.danger = false;
  }
  public void QuitApp()
  {
    PlayerSM.PlaySE("click");
    print("Quit game.");
    Application.Quit();
  }


}
