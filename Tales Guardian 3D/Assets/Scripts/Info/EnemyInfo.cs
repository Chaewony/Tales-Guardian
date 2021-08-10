using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy/EnemyInfo")]

public class EnemyInfo : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
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
    private string firstSkillName;
    [SerializeField]
    private string secondSkillName;
    [SerializeField]
    private float currentHp;

    public int[] firstSkillSecondTargetRange;
    public int[] secondSkillSecondTargetRange;

    public Sprite mySprite { get => sprite; }
    public Sprite mybattleSprite { get => battleSprite; }
    public string myCharName { get => charName; }
    public string myPosType { get => positionType; }
    public float myHp { get => fullHp; }
    public float myCurrentHp { get => currentHp; set => currentHp = value; }
    public float myAtk { get => fullAtk; }
    public float myAr { get => fullAr; }
    public float myMr { get => fullMr; }
    public string myFirstSkillName { get => firstSkillName; }
    public string mySecondSkillName { get => secondSkillName; }
}
