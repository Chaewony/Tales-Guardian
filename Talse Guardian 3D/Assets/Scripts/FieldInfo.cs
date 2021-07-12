using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Field", fileName = "Field/FieldInfo")]

public class FieldInfo : ScriptableObject
{
    [SerializeField]
    int index;
    public int myIndex { get => index; }
}
