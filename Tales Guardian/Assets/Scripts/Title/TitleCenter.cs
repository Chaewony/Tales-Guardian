using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCenter : MonoBehaviour
{
    public Image[] image;
    public bool titletouch = false;

    public void Start()
    {
        for(int i = 0; i<image.Length; i++)
        {
            image[i].color = new Color(255, 255, 255, 0);
        }
        if(titletouch == false)
        {
            StartCoroutine(FadeIn());
        }

    }

    IEnumerator FadeIn()
    {
        float fadeCount = 0;
        for (int i = 0; i < 7; i++)
        {
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.025f;
                yield return new WaitForSeconds(0.01f);
                image[i].color = new Color(255, 255, 255, fadeCount);
                if (titletouch == true)
                {
                    //Debug.Log(titletouch);
                    StopCoroutine("FadeIn");
                    for (int j = 0; j < 7; j++)
                    {
                        image[i].color = new Color(255, 255, 255, 1);
                    }
                }
            }
            fadeCount = 0;
        }
        if(GameObject.Find("StartText").GetComponent<Blink>().canblink == false)
        {
            GameObject.Find("StartText").GetComponent<Blink>().canblink = true;
            StartCoroutine(GameObject.Find("StartText").GetComponent<Blink>().BlinkText());//이거 추가
        }
        titletouch = true;
    }
}
