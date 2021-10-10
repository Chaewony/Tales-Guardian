using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePrefab : MonoBehaviour
{
    [SerializeField]
    private int Theme;
    [SerializeField]
    private bool isSelected;
    [SerializeField]
    private bool CanSelected;
    [SerializeField]
    private bool IsClear;
    [SerializeField]
    private int[] EnemyIndex;
    [SerializeField]
    private int[] EnemyArrangedIndex;
    [SerializeField]
    private int BestClearUseTurn;
    [SerializeField]
    private int[] ClearStandard;

    public int StageTheme { get => Theme; }
    public int[] StageEnemysIndex { get => EnemyIndex; }
    public int[] StageEnemysArrangedIndex { get => EnemyArrangedIndex; }
    public bool StageisSelected { get => isSelected; set { isSelected = value; } }
    public bool StageCanSelected { get => CanSelected; set { CanSelected = value; } }
    public bool StageIsClear { get => IsClear; set { IsClear = value; } }
    public int StageBestClearUseTurn { get => BestClearUseTurn; set { BestClearUseTurn = value; } }
    public int[] StageClearStandard { get => ClearStandard; }
}
