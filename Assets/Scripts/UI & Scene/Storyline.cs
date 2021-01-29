using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Storyline : MonoBehaviour
{
  public TextMeshProUGUI text;
  public GameObject proceed;
  private string currentText;
  public float textAniDelay;

  private bool skip;
  public GameObject skipButton;
  int scriptNo;
  [TextArea(3,10)]
  public string[] storyLine;
  // Start is called before the first frame update
  void Start()
  {
    proceed.SetActive(false);
    scriptNo = 0;
    currentText = storyLine[0];
  }

  public void startStory()
  {
    StartCoroutine(TextAni());
  }

  public void skipStory()
  {
    skip = true;
    skipButton.SetActive(false);
  }
  
  IEnumerator TextAni()
  {
    for(int i= 0; i < storyLine[scriptNo].Length+1; i++)
    {
      currentText = storyLine[scriptNo].Substring(0,i);
      text.text = currentText;
      if (!skip) yield return new WaitForSeconds(textAniDelay);
    }
    if(scriptNo >= storyLine.Length-1) proceed.SetActive(false);
    else proceed.SetActive(true);
    PlayerSM.PlaySE("stop");
    skip = false;
  }
  public void nextText()
  {
    scriptNo ++;

    skipButton.SetActive(true);
    PlayerSM.PlaySE("morsecode");
    proceed.SetActive(false);
    StartCoroutine(TextAni());
  }

  public void GameOn()
  {
    PlayerSM.PlaySE("click");
    SceneManager.LoadScene("levlel 1");
  }
  public void QuitGame()
  {
    PlayerSM.PlaySE("click");
    print("Quit game.");
    Application.Quit();
  }

}
