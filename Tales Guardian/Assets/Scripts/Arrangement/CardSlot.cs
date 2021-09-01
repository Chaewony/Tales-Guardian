    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
	public GameManager gameManager;
    public GameObject AllCharacterManager;

	public void OnPointerClick(PointerEventData eventData)
	{
		CardImage.sprite = character.mySprite;
		Name.text = "이름: " + character.myCharName;
		PositionType.text = "포지션 타입: " + character.myPosType;
		FirstSkillName.text = "스킬1: " + character.myFirstSkillName;
		SecondSkillName.text = "스킬2: " + character.mySecondSkillName;
		gameManager.SetAllCharactersToSelectedFalse();//미리 selected 되어있던 캐릭터의 isSelected는 꺼주기
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber = character.myLocalNumber % 100;
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharatectThemeNumber = character.myLocalNumber / 100;
		character.myIsSelected = true;
    }
}
