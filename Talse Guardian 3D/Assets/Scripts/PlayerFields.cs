using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFields : MonoBehaviour
{
    [SerializeField]
    private List<FieldInfo> allField = new List<FieldInfo>();
    [SerializeField]
    private List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    [SerializeField]
    private Texture[] fieldSprite;

    // Update is called once per frame
    void Update()
    {
        
    }
}
