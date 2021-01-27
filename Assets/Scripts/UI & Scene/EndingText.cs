using UnityEngine;
using System.Collections;
using TMPro;
public class EndingText : MonoBehaviour
{
  string beforeText;
  [TextArea(3,10)]
  public string fullText;
  public TextMeshProUGUI text;
  public float Delay;
  public GameObject end;
    // Start is called before the first frame update
  void Start()
  {
    end.SetActive(false);
    StartCoroutine(TextAni());
  }

  IEnumerator TextAni()
  {
    for(int i= 0; i < fullText.Length +1; i++)
    {
      beforeText = fullText.Substring(0,i);
      text.text = beforeText;
      yield return new WaitForSeconds(Delay);
    }
    end.SetActive(true);
  }

}
