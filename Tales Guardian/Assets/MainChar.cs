using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainChar : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> allCharacter;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < allCharacter.Count; i++)
        {
            if (allCharacter[i].GetComponent<CharactersPrefab>().IsRepreChar == true)
            {
                this.GetComponent<Image>().sprite = allCharacter[i].GetComponent<CharactersPrefab>().myIllustSprite;
                this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
