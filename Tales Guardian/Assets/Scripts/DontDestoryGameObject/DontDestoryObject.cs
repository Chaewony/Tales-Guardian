using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryObject : MonoBehaviour
{
    //public GameObject DontDestorygameobjectmanager;

    void Awake()
    {
        //DontDestorygameobjectmanager.GetComponent<DontDestroyGameObjectManager>().Character[0].GetComponent<CharactersPrefab>();
        var obj = FindObjectsOfType<DontDestoryObject>();

        int counter = 0;
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].gameObject.name == this.gameObject.name)
            {
                counter++;
            }
        }

        if (counter == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
