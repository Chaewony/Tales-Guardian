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

    void Start()
    {
        ShowCharacters();
    }

    public void ShowCharacters()
	{
        for(int i = 0; i < allCharacter.Count; i++)
		{
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].myIsOwning)
                charSlot[i].sprite = allCharacter[i].mySprite;
            else
            {
                charSlot[i].sprite = allCharacter[i].mySprite;
                charSlot[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 0.5f);
            }
        }
	}
	public void SelectMainCharacter(int index) //메인캐릭터 선택 후 화면에 보이지는 이미지
	{
        if (allCharacter[index].myIsOwning)
            illustSlot.sprite = allCharacter[index].myIllustSprite;
    }
}
