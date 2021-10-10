using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentativeCharacter : MonoBehaviour
{
    public GameObject[] AllCharacter;

    public GameObject RepresentativeCharacterImage;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AllCharacter.Length; i++)
        {
            AllCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
    }
}
