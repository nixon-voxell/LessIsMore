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
    print("Quit game.");
    Application.Quit();
  }


}
