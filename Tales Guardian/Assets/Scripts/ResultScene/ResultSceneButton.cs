using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneButton : MonoBehaviour
{
    [SerializeField]
    private ResultSceneButtonType buttonType;

    public void OnButtonClick()
    {
        switch (buttonType)
        {
            case ResultSceneButtonType.GoLobby:
                SceneManager.LoadScene("Lobby");
                break;
            case ResultSceneButtonType.GoStage:
                SceneManager.LoadScene("FirstThemeStageSelection");
                break;
            case ResultSceneButtonType.DoAgain:
                SceneManager.LoadScene("BattleArrange");
                break;
        }
    }
}
