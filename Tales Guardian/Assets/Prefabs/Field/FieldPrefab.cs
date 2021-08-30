using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPrefab : MonoBehaviour
{
    [SerializeField]
    int index;
    [SerializeField]
    public int arrangedCharIndex;

    public int myIndex { get => index; }
    public int myArrangedCharIndex { get => arrangedCharIndex; set => arrangedCharIndex = value; }
}
