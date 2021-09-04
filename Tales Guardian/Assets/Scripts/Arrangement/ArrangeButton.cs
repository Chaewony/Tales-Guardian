using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrangeButton : MonoBehaviour
{
    public ArrangementButtonType arrangeButtonType;
    public Character character;
    public GameObject AllCharacterManager;

    private void Start()
    {
        AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 9;
        character.ShowOwningCharacters();
    }

    public void OnButtonClick()
    {
        switch (arrangeButtonType)
        {
            case ArrangementButtonType.Team1:
                Debug.Log("Team1 클릭");
                break;
            case ArrangementButtonType.Team2:
                Debug.Log("Team2 클릭");
                break;
            case ArrangementButtonType.Team3:
                Debug.Log("Team3 클릭");
                break;
            case ArrangementButtonType.Theme1:
                Debug.Log("Theme1 클릭");
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 1;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.Theme2:
                Debug.Log("Theme2 클릭");
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 2;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.Theme3:
                Debug.Log("Theme3 클릭");
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 3;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.Theme4:
                Debug.Log("Theme4 클릭");
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 4;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.Theme5:
                Debug.Log("Theme5 클릭");
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 5;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.DefType:
                character.ShowDefTypeCharacters();
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 6;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.AtkType:
                character.ShowAtkTypeCharacters();
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 7;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.SupType:
                character.ShowSupTypeCharacters();
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 8;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.All:
                character.ShowOwningCharacters();
                AllCharacterManager.GetComponent<AllCharacterManager>().NowFilterType = 9;
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;
            case ArrangementButtonType.AllArrangementReset:
                AllCharacterManager.GetComponent<AllCharacterManager>().ResetTeam();
                AllCharacterManager.GetComponent<AllCharacterManager>().ClearField();
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                break;

        }
    }
}