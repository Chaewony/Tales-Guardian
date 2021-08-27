using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public ButtonType buttonType;
    public GameObject selectCharUI;
    public Character character;
    // Start is called before the first frame update

    public void OnButtonClick()
	{
		switch (buttonType)
		{
            case ButtonType.Settings:
                Debug.Log("Settings 클릭");
                break;
            case ButtonType.Library:
                Debug.Log("Library 클릭");
                SceneManager.LoadScene("Library");
                break;
            case ButtonType.Arrangement:
                Debug.Log("Arrangement 클릭");
                SceneManager.LoadScene("Arrangement");
                break;
            case ButtonType.Theme:
                Debug.Log("Theme 클릭");
                SceneManager.LoadScene("Theme");
                break;
            case ButtonType.SelectChar:
                Debug.Log("SelectChar 클릭");
                character.ShowCharacters();
                selectCharUI.SetActive(true);
                break;
            case ButtonType.Close:
                Debug.Log("창닫기 클릭");
                selectCharUI.SetActive(false);
                break;
            case ButtonType.Char0:
                character.SelectMainCharacter(0);
                break;
            case ButtonType.Char1:
                character.SelectMainCharacter(1);
                break;
            case ButtonType.Char2:
                character.SelectMainCharacter(2);
                break;
            case ButtonType.Char3:
                character.SelectMainCharacter(3);
                break;
        }
	}
}
