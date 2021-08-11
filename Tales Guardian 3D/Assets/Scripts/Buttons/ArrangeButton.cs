using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrangeButton : MonoBehaviour
{
    public ArrangementButtonType arrangeButtonType;
    public Character character;

    private void Start()
    {
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
                break;
            case ArrangementButtonType.Theme2:
                Debug.Log("Theme2 클릭");
                break;
            case ArrangementButtonType.Theme3:
                Debug.Log("Theme3 클릭");
                break;
            case ArrangementButtonType.Theme4:
                Debug.Log("Theme4 클릭");
                break;
            case ArrangementButtonType.Theme5:
                Debug.Log("Theme5 클릭");
                break;
            case ArrangementButtonType.DefType:
                character.ShowDefTypeCharacters();
                break;
            case ArrangementButtonType.AtkType:
                character.ShowAtkTypeCharacters();
                break;
            case ArrangementButtonType.SupType:
                character.ShowSupTypeCharacters();
                break;
            case ArrangementButtonType.All:
                character.ShowOwningCharacters();
                break;
        }
    }
}