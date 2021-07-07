using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    [SerializeField]
    private Image[] charSlot; //캐릭터 선택창에 띄워질 이미지 슬롯들
    [SerializeField]
    private Image illustSlot; //캐릭터 선택후 배경에 띄워질 일러스트 이미지 슬롯

    public void ShowCharacters()
	{
        for(int i = 0; i < allCharacter.Count; i++)
		{
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning)
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
                charSlot[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 1.0f);
            }
            else
            {
				charSlot[i].sprite = allCharacter[i].mySprite;
                //흑백처리 알아보기 or 검정 반투명 레이어 끼얹기
                charSlot[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 0.5f);
            }
        }
	}
	public void SelectMainCharacter(int index) //메인캐릭터 선택 후 화면에 보이지는 이미지
	{
        if (allCharacter[index].myIsOwning)
            illustSlot.sprite = allCharacter[index].myIllustSprite;
    }

    public void ShowOwningCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning)
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
            }
        }
    }
    public void ShowDefTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning&&allCharacter[i].myPosType=="Def")
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
            }
        }
    }

    public void ShowAtkTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning&&allCharacter[i].myPosType == "Atk")
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
            }
        }
    }

    public void ShowSupTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning&&allCharacter[i].myPosType == "Sup")
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
            }
        }
    }
}
