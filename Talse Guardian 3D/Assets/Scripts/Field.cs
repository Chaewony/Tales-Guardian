using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Field : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private FieldInfo field;

	public Transform fieldScale;
	public Image fieldColor;
	Vector3 defaultScale;
	Color defaultColor;
	public bool isClicked; //이 스크립트가 부착된 그리드(한 칸)이 클릭된 상태인지 아닌지 판별
	public GameManager gameManager;
	private void Start()
	{
		defaultScale = fieldScale.localScale;
		defaultColor = fieldColor.color;
		isClicked = false;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isClicked)
		{
			fieldScale.localScale = defaultScale * 1.05f;
			fieldColor.color = new Color(fieldColor.color.r, 0.25f, fieldColor.color.b);
		}
		else return;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		fieldScale.localScale = defaultScale;
		if (!isClicked)
		{
			fieldColor.color = defaultColor;
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
			fieldColor.color = new Color(1f, 1f, 1f);
			//캐릭터 리스트를 돌면서 isSelected가 true로 되어있는 캐릭터의 정보를 가져온다
			for (int i = 0; i < gameManager.allCharacter.Count; i++) {
				if (gameManager.allCharacter[i].myIsSelected)
				{
					fieldColor.sprite = gameManager.allCharacter[i].mybattleSprite;
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
			fieldColor.color = defaultColor;
			fieldColor.sprite = null; //재클릭시 이미지 빼기(선택 해제)
		}
	}
}
