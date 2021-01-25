using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneControl : MonoBehaviour
{
  public TextMeshProUGUI text;
  public GameObject proceed;
  public int lines;
  int scriptNo;
  [TextArea(3,10)]
  public string[] storyLine;
  void Start()
  {
    proceed.SetActive(true);
    scriptNo = 0;
    text.text= storyLine[0];
  }
  public void GameOn()
  {
    SceneManager.LoadScene("Movement");
  }

  public void QuitGame()
  {
    print("Quit game.");
    Application.Quit();
  }

  public void nextText()
  {
    scriptNo ++;
    text.text = storyLine[scriptNo];
    if(scriptNo == lines) proceed.SetActive(false);
  }


}
