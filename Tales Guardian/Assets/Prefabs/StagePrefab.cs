using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePrefab : MonoBehaviour
{
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

    public int[] StageEnemysIndex { get => EnemyIndex; }
    public int[] StageEnemysArrangedIndex { get => EnemyArrangedIndex; }
    public bool StageisSelected { get => isSelected; set { isSelected = value; } }
    public bool StageCanSelected { get => CanSelected; set { CanSelected = value; } }
    public bool StageIsClear { get => IsClear; set { IsClear = value; } }
}
