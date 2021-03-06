using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AllCharacterManager : MonoBehaviour
{ // ㅁㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄹ
    public CharacterInfo[] allCharacter;
    public int SelectCharacterNumber;
    public Image[] AllField;
    public int ArrangementCount;
    public int SelectCharatectThemeNumber;
    public int NowFilterType;
    public Character character;

    public GameObject[] CharacterPrefabs;
    public GameObject[] FieldPrefabs;

    public GameObject[] DissolutionButton;
    public CardSlot CardSlot;
    public CardSlot CardSlot1;

    Color defaultColor;
    public Image fieldColor;

    //FieldPrefabs.GetComponent<FieldPrefab>() CharacterPrefabs[i].GetComponent<CharactersPrefab>()

    public void Start()
    {
        defaultColor = fieldColor.color;
        CardSlot = this.gameObject.GetComponent<CardSlot>();

        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            CharacterPrefabs[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < FieldPrefabs.Length; i++)
        {
            FieldPrefabs[i] = GameObject.Find("DDField").transform.GetChild(i).gameObject;
        }


        //ResetTeam(); // 임시로 초기상태로 돌리는 함수 /*/ 나중에 여기꺼는 꼭 빼야됨 /*/
        ClearField();
        FillField();
        DrawField();
        SelectCharacterNumber = -1;
        ArrangementCounting();
        //CardSlot1.FillCardSlot();
    }

    public void ArrangementCounting()
    {
        ArrangementCount = 0;
        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            if (CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation != -1)
            {
                ArrangementCount++;
            }
        }
    }

    public void ResetTeam()
    {
        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation = -1;
        }
        for (int i = 0; i < FieldPrefabs.Length; i++)
        {
            FieldPrefabs[i].GetComponent<FieldPrefab>().myArrangedCharIndex = -1;
        }
        ArrangementCount = 0;
    }

    public void ResetSelected()
    {
        SelectCharacterNumber = -1;
        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsSelected = false;
        }
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
        for(int i = 0; i< FieldPrefabs.Length;i++)
        {
            FieldPrefabs[i].GetComponent<FieldPrefab>().myArrangedCharIndex = -1;
        }
        for(int i = 0; i< CharacterPrefabs.Length;i++)
        {
            if (CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation != -1) // 배치된 상태의 캐릭터
            {
                FieldPrefabs[CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation].GetComponent<FieldPrefab>().myArrangedCharIndex = CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocalNumber % 100;
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
                //AllField[i].color = new Color(1f, 1f, 1f);
                AllField[i].color = defaultColor;
            }
        }
    }

    public void DrawField()
    {
        for (int i = 0; i< CharacterPrefabs.Length; i++)
        {
            if(CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation != -1 )
            {
                AllField[CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation].sprite = CharacterPrefabs[i].GetComponent<CharactersPrefab>().mySprite;
                AllField[CharacterPrefabs[i].GetComponent<CharactersPrefab>().myLocation].color = new Color(1, 1, 1, 1);
            }
        }
    }
}
