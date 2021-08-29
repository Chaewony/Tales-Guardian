﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysPrefab : MonoBehaviour
{
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
    [SerializeField]
    private float currentAtk;
    [SerializeField]
    private float currentAr;
    [SerializeField]
    private float currentMr;
    [SerializeField]
    private int Location;

    public int[] firstSkillSecondTargetRange;
    public int[] secondSkillSecondTargetRange;

    public Sprite mybattleSprite { get => battleSprite; }
    public string myCharName { get => charName; }
    public string myPosType { get => positionType; }
    public float myFullHp { get => fullHp; }
    public float myFullAtk { get => fullAtk; }
    public float myFullAr { get => fullAr; }
    public float myFullMr { get => fullMr; }
    public float myCurrentHp { get => currentHp; set => currentHp = value; }
    public float myCurrentAtk { get => currentAtk; set => currentAtk = value; }
    public float myCurrentAr { get => currentAr; set => currentAr = value; }
    public float myCurrentMr { get => currentMr; set => currentMr = value; }
    public string myFirstSkillName { get => firstSkillName; }
    public string mySecondSkillName { get => secondSkillName; }
    public int myLocation { get => Location; set { Location = value; } }
}
