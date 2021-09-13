using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleArranger : MonoBehaviour
{
    public List<GameObject> allField = new List<GameObject>();
    public Image[] field;
    public List<GameObject> allCharacter = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < allField.Count; i++)
        {
            allField[i] = GameObject.Find("DDField").transform.GetChild(i).gameObject;
        }
        FillField();
        SetImage();
    }

    void FillField()
    {
        for (int i = 0; i < allField.Count; i++)
        {
            allField[i].GetComponent<FieldPrefab>().myArrangedCharIndex = -1;
        }
        for (int i = 0; i < allCharacter.Count; i++)
        {
            if (allCharacter[i].GetComponent<CharactersPrefab>().myLocation != -1) // 배치된 상태의 캐릭터
            {
                allField[allCharacter[i].GetComponent<CharactersPrefab>().myLocation].GetComponent<FieldPrefab>().myArrangedCharIndex = allCharacter[i].GetComponent<CharactersPrefab>().myLocalNumber % 100;
            }
        }
    }

    void SetImage() //배치된 캐릭터들을 하나의 리스트에 저장
    {
        for (int i = 0; i < allField.Count; i++)
        {
            if (allField[i].GetComponent<FieldPrefab>().myArrangedCharIndex != -1)
            {
                field[i].color = new Color(1, 1, 1);
                field[i].sprite = allCharacter[allField[i].GetComponent<FieldPrefab>().myArrangedCharIndex].GetComponent<CharactersPrefab>().mybattleSprite;
            }
        }
    }
 }

