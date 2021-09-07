using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
[CreateAssetMenu(menuName = "Field", fileName = "Field/FieldInfo")]

public class FieldInfo : ScriptableObject
{
    [SerializeField]
    int index;
    [SerializeField]
    int arrangedCharIndex;

    public int myIndex { get => index; }
    public int myArrangedCharIndex { get => arrangedCharIndex; set => arrangedCharIndex = value; }
}
