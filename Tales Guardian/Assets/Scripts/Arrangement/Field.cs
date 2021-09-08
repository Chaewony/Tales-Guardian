using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int FieldNumber;
    public GameObject FieldPrefab;
	public Transform fieldScale;
	public Image fieldColor;
	Vector3 defaultScale;
	Color defaultColor;
	public bool isFill; //이 스크립트가 부착된 그리드(한 칸)이 클릭된 상태인지 아닌지 판별 --> 그리드에 캐릭터가 할당되어있는지
	//public GameManager gameManager;

	private void Start()
	{
        FieldPrefab = GameObject.Find("DDField").transform.GetChild(FieldNumber).gameObject;
        defaultScale = fieldScale.localScale;
		defaultColor = fieldColor.color;
		isFill = false;
        //field.myArrangedCharIndex = -1;
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        fieldScale.localScale = defaultScale * 1.05f;
		if (FieldPrefab.GetComponent<FieldPrefab>().myArrangedCharIndex != -1)
		{
			fieldColor.color = new Color(1f, 1f, 1f);
		}
        else
        {
            fieldColor.color = new Color(fieldColor.color.r, 0.25f, fieldColor.color.b);
        }
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		fieldScale.localScale = defaultScale;
        if (FieldPrefab.GetComponent<FieldPrefab>().myArrangedCharIndex != -1)
        {
            fieldColor.color = new Color(1f, 1f, 1f);
        }
        else
        {
            fieldColor.color = defaultColor;
        }
    }
    
	public void OnPointerClick(PointerEventData eventData)
	{
	/*	//클릭되지 않은 상태의 그리드를 클릭했을 때
		if (!isFill && gameManager.canClickGrid)
        {
            //그리드 선택
            isFill = true;
			//gridColor.color = new Color(gridColor.color.r, 0.25f, gridColor.color.b);
			fieldColor.color = new Color(1f, 1f, 1f);
			//캐릭터 리스트를 돌면서 isSelected가 true로 되어있는 캐릭터의 정보를 가져온다
			for (int i = 0; i < gameManager.allCharacter.Count; i++) {
				if (gameManager.allCharacter[i].myIsSelected)
				{
					fieldColor.sprite = gameManager.allCharacter[i].mybattleSprite;
					field.myArrangedCharIndex = i;
					//gridColor.color = defaultColor;
					gameManager.arrangementCount++;
				}
			}
			gameManager.SetAllCharactersToSelectedFalse();
		}
		//클릭된 상태의 그리드를 클릭했을 때 (그리드 선택 해제는 언제든지 가능)
		else if(isFill)
		{
            //그리드 선택 해제
            isFill = false;
			fieldColor.color = defaultColor;
			fieldColor.sprite = null; //재클릭시 이미지 빼기(선택 해제)
			gameManager.slot[field.myArrangedCharIndex].gameObject.SetActive(true);
			field.myArrangedCharIndex = -1;
			gameManager.arrangementCount--;
		}
        */
	}
    
}
