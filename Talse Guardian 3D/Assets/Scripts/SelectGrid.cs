using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public Transform gridScale;
	public Image gridColor;
	Vector3 defaultScale;
	Color defaultColor;
	public bool isClicked; //이 스크립트가 부착된 그리드(한 칸)이 클릭된 상태인지 아닌지 판별
	public GameManager gameManager;
	private void Start()
	{
		defaultScale = gridScale.localScale;
		defaultColor = gridColor.color;
		isClicked = false;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isClicked)
		{
			gridScale.localScale = defaultScale * 1.05f;
			gridColor.color = new Color(gridColor.color.r, 0.25f, gridColor.color.b);
		}
		else return;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gridScale.localScale = defaultScale;
		if (!isClicked)
		{
			gridColor.color = defaultColor;
		}
		else return;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		//클릭되지 않은 상태의 그리드를 클릭했을 때
		if (!isClicked&&gameManager.canClickGrid)
		{
			//그리드 선택
			isClicked = true;
			//gridColor.color = new Color(gridColor.color.r, 0.25f, gridColor.color.b);
			gridColor.color = new Color(1f, 1f, 1f);
			//캐릭터 리스트를 돌면서 isSelected가 true로 되어있는 캐릭터의 정보를 가져온다
			for (int i = 0; i < gameManager.allCharacter.Count; i++) {
				if (gameManager.allCharacter[i].myIsSelected)
				{
					gridColor.sprite = gameManager.allCharacter[i].mybattleSprite;
					//gridColor.color = defaultColor;
				}
			}
			gameManager.SetAllCharactersToSelectedFalse();
		}
		//클릭된 상태의 그리드를 클릭했을 때 (그리드 선택 해제는 언제든지 가능)
		else if(isClicked)
		{
			//그리드 선택 해제
			isClicked = false;
			gridColor.color = defaultColor;
			gridColor.sprite = null; //재클릭시 이미지 빼기(선택 해제)
		}
	}
}
