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
                Debug.Log("방어형 클릭");
                character.ShowDefTypeCharacters();
                break;
            case ArrangementButtonType.AtkType:
                Debug.Log("공격형 클릭");
                character.ShowAtkTypeCharacters();
                break;
            case ArrangementButtonType.SupType:
                Debug.Log("보조형 클릭");
                character.ShowSupTypeCharacters();
                break;
            case ArrangementButtonType.All:
                Debug.Log("전체 보기 클릭");
                character.ShowOwningCharacters();
                break;
        }
    }
}
