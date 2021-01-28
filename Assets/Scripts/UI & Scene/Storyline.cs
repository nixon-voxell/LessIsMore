using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Storyline : MonoBehaviour
{
  public TextMeshProUGUI text;
  public GameObject proceed;
  public int lines;
  private string currentText;
  public float textAniDelay;
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
  
  IEnumerator TextAni()
  {
    for(int i= 0; i < storyLine[scriptNo].Length+1; i++)
    {
      currentText = storyLine[scriptNo].Substring(0,i);
      text.text = currentText;
      yield return new WaitForSeconds(textAniDelay);
    }
    proceed.SetActive(true);
    PlayerSM.PlaySE("stop");
  }
  public void nextText()
  {
    PlayerSM.PlaySE("morsecode");
    proceed.SetActive(false);
    scriptNo ++;
    StartCoroutine(TextAni());
    if(scriptNo == lines) proceed.SetActive(false);
  }

    public void GameOn()
  {
    PlayerSM.PlaySE("click");
    SceneManager.LoadScene("Movement");
  }
  public void QuitGame()
  {
    PlayerSM.PlaySE("click");
    print("Quit game.");
    Application.Quit();
  }

}
