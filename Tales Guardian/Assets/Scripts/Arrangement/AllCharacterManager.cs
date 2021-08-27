using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AllCharacterManager : MonoBehaviour
{
    public CharacterInfo[] allCharacter;
    public int SelectCharacterNumber;
    public Image[] AllField;
    public int ArrangementCount;
    public int SelectCharatectThemeNumber;
    public FieldInfo[] RealAllField;
    public int NowFilterType;
    public Character character;

    public void Start()
    {
        //ResetTeam(); // 임시로 초기상태로 돌리는 함수 /*/ 나중에 여기꺼는 꼭 빼야됨 /*/
        ClearField();
        DrawField();
        FillField();
        SelectCharacterNumber = -1;
        ArrangementCount = 0;
        for (int i = 0; i < allCharacter.Length; i++)
        {
            if (allCharacter[i].myLocation != -1)
            {
                ArrangementCount++;
            }
        }
    }

    public void ResetTeam()
    {
        for (int i = 0; i < allCharacter.Length; i++)
        {
            allCharacter[i].myLocation = -1;
        }
        for (int i = 0; i < RealAllField.Length; i++)
        {
            RealAllField[i].myArrangedCharIndex = -1;
        }
        ArrangementCount = 0;
    }

    public void Update()
    {
        
    }

    public void SeeNowFilterType()
    {
        switch(NowFilterType)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                character.ShowDefTypeCharacters();
                break;
            case 7:
                character.ShowAtkTypeCharacters();
                break;
            case 8:
                character.ShowSupTypeCharacters();
                break;
            case 9:
                character.ShowOwningCharacters();
                break;
        }
    }

    public void FillField()
    {
        for(int i = 0; i<RealAllField.Length;i++)
        {
            RealAllField[i].myArrangedCharIndex = -1;
        }
        for(int i = 0; i<allCharacter.Length;i++)
        {
            if(allCharacter[i].myLocation != -1) // 배치된 상태의 캐릭터
            {
                RealAllField[allCharacter[i].myLocation].myArrangedCharIndex = allCharacter[i].myLocalNumber % 100;
            }
        }
    }

    public void ClearField()
    {
        for (int i = 0; i < AllField.Length; i++)
        {
            if(AllField[i].sprite != null)
            {
                AllField[i].sprite = null;
                AllField[i].color = new Color(1f, 0.45f, 0.45f, 1);
            }
        }
    }

    public void DrawField()
    {
        for (int i = 0; i<allCharacter.Length; i++)
        {
            if(allCharacter[i].myLocation != -1 )
            {
                AllField[allCharacter[i].myLocation].sprite = allCharacter[i].mySprite;
                AllField[allCharacter[i].myLocation].color = new Color(1, 1, 1, 1);
            }
        }
    }
}
