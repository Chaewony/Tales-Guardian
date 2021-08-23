using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="StageInfo",fileName = "Stage/StageInfo")]

public class StageInfo : ScriptableObject
{
    public bool isSelected;
    [SerializeField]
    public int[] EnemyIndex;
    [SerializeField]
    public int[] EnemyArrangedIndex;

    public int[] StageCharactersIndex { get => EnemyIndex; }
    public int[] StageCharactersArrangedIndex { get => EnemyArrangedIndex; }
}
