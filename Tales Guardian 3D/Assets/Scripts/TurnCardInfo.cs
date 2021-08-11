using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "TurnCard", fileName = "TurnCard/TurnCardInfo")]

public class TurnCardInfo : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int cardNum; //인덱스값 아니고 숫자

    public Sprite mySprite { get => sprite; }
    public int myCardNum { get => cardNum; }
}
