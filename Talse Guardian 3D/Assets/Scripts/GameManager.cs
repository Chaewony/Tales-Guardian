using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public bool canClickGrid; //그리드가 클릭될 수 있는 상태인지 아닌지 판별

	private void Start()
	{
        canClickGrid = false;
        SetAllCharactersToSelectedFalse();

    }
	// Update is called once per frame
	void Update()
    {
        //그리드가 클릭될 수 있는 상태인지 아닌지 판별, 가지고 있는 카드 중 셀렉된 캐릭터가 있으면true, 아니면 false
        for (int i = 0; i < allCharacter.Count; i++)
        {
            if (allCharacter[i].myIsOwning && !allCharacter[i].myIsSelected) 
            {
                canClickGrid = false;
            }
            else if (allCharacter[i].myIsOwning && allCharacter[i].myIsSelected)
			{
                canClickGrid = true;
                break;
            }
        }
    }
    /*카드 슬롯 중 하나가 클릭 되면 실행되는 함수. 각 캐릭터들의 isSelected 변수를 관리해줌
     isSelected 변수는 리스트 중 하나의 요소(캐릭터)만 true값을 가질 수 있음 */
    public void SetAllCharactersToSelectedFalse()
	{
        for (int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i].myIsSelected = false;
        }
    }

    /*그리드 중 4칸이 모두 클릭된 상태(isClicked=true)일 경우 더이상 can Click을 false로 바꿔주기
     그리드 리스트 만들 것*/
}
