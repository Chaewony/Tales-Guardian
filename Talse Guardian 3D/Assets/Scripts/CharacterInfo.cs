using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName ="Character", fileName ="Character/CharacterInfo")]

public class CharacterInfo : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Sprite illustSprite;
    [SerializeField]
    private string charName;
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

    public Sprite mySprite { get => sprite; }
    public Sprite myIllustSprite { get => illustSprite; }
    public string myCharName { get => charName; }
    public float myHp { get => fullHp; }
    public float myAtk { get => fullAtk; }
    public float myAr { get => fullAr; }
    public float myMr { get => fullMr; }
    public bool myIsOwning { get => isOwning; }
}
