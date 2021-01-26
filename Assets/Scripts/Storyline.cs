using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Storyline : MonoBehaviour
{
  public TextMeshProUGUI text;
  public GameObject proceed;
  public int lines;
  int scriptNo;
  [TextArea(3,10)]
  public string[] storyLine;
  // Start is called before the first frame update
  void Start()
  {
    proceed.SetActive(true);
    scriptNo = 0;
    text.text= storyLine[0];
  }

  public void nextText()
  {
    SoundManager.PlaySE("morseEffect");
    scriptNo ++;
    text.text = storyLine[scriptNo];
    if(scriptNo == lines) proceed.SetActive(false);
  }
  
    public void GameOn()
  {
    SoundManager.PlaySE("click");
    SceneManager.LoadScene("Movement");
  }
  public void QuitGame()
  {
    SoundManager.PlaySE("click");
    print("Quit game.");
    Application.Quit();
  }

}
