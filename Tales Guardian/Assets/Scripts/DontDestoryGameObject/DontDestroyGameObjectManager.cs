using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameObjectManager : MonoBehaviour
{
    public GameObject[] Character;
    public GameObject[] Enemy;

    public GameObject[] Stage;
    public GameObject[] Field;
    public GameObject[] EnemyField;
    public GameObject User;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Character.Length; i++)
        {
            Character[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }

        Field[0] = GameObject.Find("Field0");
        Field[1] = GameObject.Find("Field1");
        Field[2] = GameObject.Find("Field2");
        Field[3] = GameObject.Find("Field3");
        Field[4] = GameObject.Find("Field4");
        Field[5] = GameObject.Find("Field5");
        Field[6] = GameObject.Find("Field6");
        Field[7] = GameObject.Find("Field7");
        Field[8] = GameObject.Find("Field8");

        /*
        EnemyField[0] = GameObject.Find("EnemyField0");
        EnemyField[1] = GameObject.Find("EnemyField1");
        EnemyField[2] = GameObject.Find("EnemyField2");
        EnemyField[3] = GameObject.Find("EnemyField3");
        EnemyField[4] = GameObject.Find("EnemyField4");
        EnemyField[5] = GameObject.Find("EnemyField5");
        EnemyField[6] = GameObject.Find("EnemyField6");
        EnemyField[7] = GameObject.Find("EnemyField7");
        EnemyField[8] = GameObject.Find("EnemyField8");
        */

        Stage[0] = GameObject.Find("Stage1-1");
        Stage[1] = GameObject.Find("Stage1-2");
        Stage[2] = GameObject.Find("Stage1-3");
        Stage[3] = GameObject.Find("Stage1-4");
        Stage[4] = GameObject.Find("Stage1-5");

        User = GameObject.Find("User");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
