using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
  public void replay() // load level 1
  {
    SceneManager.LoadScene("Movement");
  }
  public void QuitApp()
  {
    PlayerSM.PlaySE("click");
    print("Quit game.");
    Application.Quit();
  }


}
