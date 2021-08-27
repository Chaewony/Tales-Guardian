using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
[CreateAssetMenu(menuName ="Character", fileName ="Character/CharacterInfo")]

public class CharacterInfo : ScriptableObject
{
    [SerializeField]
    private int LocalNumber;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Sprite illustSprite;
    [SerializeField]
    private Sprite battleSprite;
    [SerializeField]
    private string charName;
    [SerializeField]
    private string rank; //등급
    [SerializeField]
    private string positionType; //포지션
    [SerializeField]
    private float fullHp;
    [SerializeField]
    private float fullAtk;
    [SerializeField]
    private float fullAr; //Armor 물리방어력
    [SerializeField]
    private float fullMr; //Magic resist 마법방어력
    [SerializeField]
    private bool isOwning; //플레이어가 가지고 있는 카드인지
    [SerializeField]
    private string firstSkillName;
    [SerializeField]
    private string secondSkillName;
    [SerializeField]
    private bool isSelected;
    [SerializeField]
    private float currentHp;
    [SerializeField]
    private float HaveManyCard;
    [SerializeField]
    private float EnhanceStep;
    [SerializeField]
    private int Location;

    public int[] firstSkillSecondTargetRange;
    public int[] secondSkillSecondTargetRange;

    public int myLocalNumber { get => LocalNumber; }
    public Sprite mySprite { get => sprite; }
    public Sprite myIllustSprite { get => illustSprite; }
    public Sprite mybattleSprite { get => battleSprite; }
    public string myCharName { get => charName; }
    public string myPosType { get => positionType; }
    public float myHp { get => fullHp; set { fullHp = value; } }
    public float myCurrentHp { get => currentHp; set => currentHp = value; }
    public float myAtk { get => fullAtk; set { fullAtk = value; } }
    public float myAr { get => fullAr; set { fullAr = value; } }
    public float myMr { get => fullMr; set { fullMr = value; } }
    public bool myIsOwning { get => isOwning; set { isOwning = value; } }
    public string myFirstSkillName { get => firstSkillName; }
    public string mySecondSkillName { get => secondSkillName; }
    public bool myIsSelected { get => isSelected; set => isSelected = value; }
    public float myHaveManyCard { get => HaveManyCard; set { HaveManyCard = value; } }
    public float myEnhanceStep { get => EnhanceStep; set { EnhanceStep = value; } }
    public int myLocation { get => Location; set { Location = value; } }
}
