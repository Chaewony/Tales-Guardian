using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePrefab : MonoBehaviour
{
    public bool isSelected;
    public bool CanSelected;
    [SerializeField]
    private int[] EnemyIndex;
    [SerializeField]
    private int[] EnemyArrangedIndex;

    public int[] StageCharactersIndex { get => EnemyIndex; }
    public int[] StageCharactersArrangedIndex { get => EnemyArrangedIndex; }
}
