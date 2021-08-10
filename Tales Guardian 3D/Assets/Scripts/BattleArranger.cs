using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleArranger : MonoBehaviour
{
    public List<FieldInfo> allField = new List<FieldInfo>(); //스크립터블 오브젝트
    public Image[] field;
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();

    private void Start()
    {
        SetImage();
    }

    void SetImage() //배치된 캐릭터들을 하나의 리스트에 저장
    {
        for (int i = 0; i < allField.Count; i++)
        {
            if (allField[i].myArrangedCharIndex != -1)
            {
                field[i].color = new Color(1, 1, 1);
                field[i].sprite = allCharacter[allField[i].myArrangedCharIndex].mybattleSprite;
            }
        }
    }
 }

