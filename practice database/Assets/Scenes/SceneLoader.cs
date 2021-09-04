using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject[] character;
    void Start()
    {
        character1 = GameObject.Find("Capsule");
        character2 = GameObject.Find("Capsule (1)");
        character3 = GameObject.Find("Capsule (2)");

        Debug.Log(character1.GetComponent<DontDestoryObject>().testintiager);
        Debug.Log(character2.GetComponent<DontDestoryObject>().testintiager);
        Debug.Log(character3.GetComponent<DontDestoryObject>().testintiager);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("New Scene");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
