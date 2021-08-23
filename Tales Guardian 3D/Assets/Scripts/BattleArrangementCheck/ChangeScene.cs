using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    public SceneButtonType scenebuttontype;
    public void OnButtonClick()
    {
        switch (scenebuttontype)
        {
            case SceneButtonType.BattleArrangeButton:
                SceneManager.LoadScene("Arrangement");
                Debug.Log("배치로");
                break;
            case SceneButtonType.CloseButton:              
                Debug.Log("닫기");
                break;
            case SceneButtonType.StartButton:
                SceneManager.LoadScene("Battle");
                Debug.Log("배틀시작");
                break;
        }
    }
}
