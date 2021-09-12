using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLobby: MonoBehaviour
{

    public void ChangeScene()
    {
        if (GameObject.Find("Main Camera").GetComponent<TitleCenter>().titletouch == false)
        {
            GameObject.Find("Main Camera").GetComponent<TitleCenter>().titletouch = true;
            for (int i = 0; i < 7; i++)
            {
                GameObject.Find("Main Camera").GetComponent<TitleCenter>().image[i].color = new Color(255, 255, 255, 1);
            }
            GameObject.Find("StartText").GetComponent<Blink>().canblink = true;
            StartCoroutine(GameObject.Find("StartText").GetComponent<Blink>().BlinkText());//이거 추가
        }
        else if (GameObject.Find("Main Camera").GetComponent<TitleCenter>().titletouch == true)
            SceneManager.LoadScene("Lobby");
    }
}
