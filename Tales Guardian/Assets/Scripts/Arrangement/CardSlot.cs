    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CardSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int SlotNumber;
    [SerializeField]
    private GameObject character;
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

    public void Start()
    {
        character = GameObject.Find("DDCharacters").transform.GetChild(SlotNumber).gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
	{
        CardImage.color = new Color(1f, 1f, 1f, 1f);
        CardImage.sprite = character.GetComponent<CharactersPrefab>().mySprite;
		Name.text = "이름: " + character.GetComponent<CharactersPrefab>().myCharName;
		PositionType.text = "포지션 타입: " + character.GetComponent<CharactersPrefab>().myPosType;
		FirstSkillName.text = "스킬1: " + character.GetComponent<CharactersPrefab>().myFirstSkillName;
		SecondSkillName.text = "스킬2: " + character.GetComponent<CharactersPrefab>().mySecondSkillName;
		gameManager.SetAllCharactersToSelectedFalse();//미리 selected 되어있던 캐릭터의 isSelected는 꺼주기
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber = character.GetComponent<CharactersPrefab>().myLocalNumber % 100;
        Debug.Log(character.GetComponent<CharactersPrefab>().myLocalNumber % 100 + "이랑" + AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber);
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharatectThemeNumber = character.GetComponent<CharactersPrefab>().myLocalNumber / 100;
		character.GetComponent<CharactersPrefab>().myIsSelected = true;
    }

    public void ResetCardSlot()
    {
        CardImage.sprite = character.GetComponent<CharactersPrefab>().mySprite;
        CardImage.color = new Color(1f, 1f, 1f, 0);
        Name.text = "이름: ";
        PositionType.text = "포지션 타입: ";
        FirstSkillName.text = "스킬1: ";
        SecondSkillName.text = "스킬2: ";
    }
}
