using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    public SceneButtonType scenebuttontype;
    [SerializeField]
    private GameObject WarringMassage;
    [SerializeField]
    private List<GameObject> allCharacter;
    [SerializeField]
    private int InFeildCharacter;

    public void Start()
    {
        InFeildCharacter = 0;
        for (int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < allCharacter.Count; i++)
        {
            if(allCharacter[i].GetComponent<CharactersPrefab>().myLocation != -1)
            {
                InFeildCharacter++;
            }
        }
    }

    public void OnButtonClick()
    {
        switch (scenebuttontype)
        {
            case SceneButtonType.BattleArrangeButton:
                SceneManager.LoadScene("BattleArrangementCheck");
                Debug.Log("배치로");
                break;
            case SceneButtonType.CloseButton:              
                Debug.Log("닫기");
                SceneManager.LoadScene("FirstThemeStageSelection");
                break;
            case SceneButtonType.StartButton:
                if(InFeildCharacter != 0)
                {
                    Debug.Log("배틀시작");
                    SceneManager.LoadScene("Battle");
                }
                else if (InFeildCharacter == 0)
                {
                    WarringMassage.SetActive(true);
                }
                break;
            case SceneButtonType.CloseWarringButton:
                WarringMassage.SetActive(false);
                break;
        }
    }
}
