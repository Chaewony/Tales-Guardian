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
    private Text HP;
    [SerializeField]
    private Text ATK;
    [SerializeField]
    private Text AR;
    [SerializeField]
    private Text MR;
    [SerializeField]
	private Text PositionType;
	[SerializeField]
	private Text FirstSkillName;
	[SerializeField]
	private Text SecondSkillName;
    [SerializeField]
    private Image FirstSkillImage;
    [SerializeField]
    private Image SecondSkillImage;
    public GameManager gameManager;
    public GameObject AllCharacterManager;

    public void Start()
    {
        character = GameObject.Find("DDCharacters").transform.GetChild(SlotNumber).gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
	{
        FillCardSlot();
    }

    public void FillCardSlot()
    {
        CardImage.color = new Color(1f, 1f, 1f, 1f);
        CardImage.sprite = character.GetComponent<CharactersPrefab>().mySprite;
		Name.text = "이름: " + character.GetComponent<CharactersPrefab>().myCharName;
		PositionType.text = "포지션 타입: " + character.GetComponent<CharactersPrefab>().myPosType;
		FirstSkillName.text = character.GetComponent<CharactersPrefab>().myFirstSkillName;
		SecondSkillName.text = character.GetComponent<CharactersPrefab>().mySecondSkillName;
        HP.text = character.GetComponent<CharactersPrefab>().myHp.ToString();
        ATK.text = character.GetComponent<CharactersPrefab>().myAtk.ToString();
        AR.text = character.GetComponent<CharactersPrefab>().myAr.ToString();
        MR.text = character.GetComponent<CharactersPrefab>().myMr.ToString();
        gameManager.SetAllCharactersToSelectedFalse();//미리 selected 되어있던 캐릭터의 isSelected는 꺼주기
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber = character.GetComponent<CharactersPrefab>().myLocalNumber % 100;
        AllCharacterManager.GetComponent<AllCharacterManager>().SelectCharatectThemeNumber = character.GetComponent<CharactersPrefab>().myLocalNumber / 100;
		character.GetComponent<CharactersPrefab>().myIsSelected = true;
        FirstSkillImage.sprite = character.GetComponent<CharactersPrefab>().myfirstSkillSprite;
        SecondSkillImage.sprite = character.GetComponent<CharactersPrefab>().mySecondSkillSprite;
    }

    public void ResetCardSlot()
    {
        CardImage.sprite = character.GetComponent<CharactersPrefab>().mySprite;
        CardImage.color = new Color(1f, 1f, 1f, 0);
        Name.text = "이름";
        PositionType.text = "포지션";
        FirstSkillName.text = "스킬1";
        SecondSkillName.text = "스킬2";
        HP.text = " ";
        ATK.text = " ";
        AR.text = " ";
        MR.text = " ";
        FirstSkillImage.sprite = character.GetComponent<CharactersPrefab>().myfirstSkillSprite;
        FirstSkillImage.color = new Color(1f, 1f, 1f, 0);
        SecondSkillImage.sprite = character.GetComponent<CharactersPrefab>().mySecondSkillSprite;
        SecondSkillImage.color = new Color(1f, 1f, 1f, 0);
    }
}
