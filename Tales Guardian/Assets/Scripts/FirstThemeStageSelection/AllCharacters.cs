using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCharacters : MonoBehaviour
{
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public GameObject[] CharacterPrefabs;

    /*
    {
        CharacterPrefabs[0].GetComponent<CharactersPrefab>().myIsOwning = true; // 프리팹 쓰는법
        allcharacter.myIsowning = true; // 스크랩터블오브젝트 쓰는법
    }
    */
}
