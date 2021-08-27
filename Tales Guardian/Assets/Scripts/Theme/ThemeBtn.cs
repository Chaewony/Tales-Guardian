using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ThemeBtn : MonoBehaviour
{
    public ThemeButtonType TmButtonType;
    public GameObject ThemeSettingUI;
    public GameObject CloseThemeBtn;
    public GameObject UICheck;

    private void Start()
    {

    }

    public void OnButtonClick()
    {
        switch (TmButtonType)
        {
            case ThemeButtonType.ThemeHome:
                SceneManager.LoadScene("Lobby");
                Debug.Log("로비로 이동");
                break;
            case ThemeButtonType.ThemeSetting:
                Debug.Log("테마 설정 클릭");
                ThemeSettingUI.SetActive(true);
                break;
            case ThemeButtonType.ThemeSettingClose:
                Debug.Log("창닫기 클릭");
                ThemeSettingUI.SetActive(false);
                break;
            case ThemeButtonType.ThemeGameQuit:
                Debug.Log("게임 종료");
                Application.Quit();
                break;

        }
    
    }
}
