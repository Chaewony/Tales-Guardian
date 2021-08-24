using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Blink : MonoBehaviour
{
    Text flashingText;
    public bool canblink = false;

    public void FixedUpdate()
    {
        StartCoroutine(BlinkText());
    }
    public IEnumerator BlinkText()
    {
        flashingText = GetComponent<Text>();

        while (canblink == true)
        {
            flashingText.text = " ";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "TOUCH TO START";
            yield return new WaitForSeconds(.5f);
        }
 
    } 
}
