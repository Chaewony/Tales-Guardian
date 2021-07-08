using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CardSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private CharacterInfo character;
	[SerializeField]
	private Image CardImage;
	[SerializeField]
	private Text Name;
	[SerializeField]
	private Text PositionType;
	[SerializeField]
	private Text FirstSkillName;
	[SerializeField]
	private Text SecondSkillName;

	public void OnPointerClick(PointerEventData eventData)
	{
		CardImage.sprite = character.mySprite;
		Name.text = "이름: " + character.myCharName;
		PositionType.text = "포지션 타입: " + character.myPosType;
		FirstSkillName.text = "스킬1: " + character.myFirstSkillName;
		SecondSkillName.text = "스킬2: " + character.mySecondSkillName;
	}
}
