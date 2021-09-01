using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Blink : MonoBehaviour
{
    Text flashingText;
    public bool canblink = false;
    public void Start()
    {
        flashingText = GetComponent<Text>();
    }

    public void Update()
    {
        if(canblink)
        {
            StartCoroutine(BlinkText());
        }   
    }

    public IEnumerator BlinkText()
    {
        while(canblink)
        {
            flashingText.text = " ";        
            yield return new WaitForSecondsRealtime(.5f);
            flashingText.text = "TOUCH TO START";
            yield return new WaitForSecondsRealtime(.5f);
        }
    } 
}
