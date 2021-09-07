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
        Character[0] = GameObject.Find("Character100");
        Character[1] = GameObject.Find("Character101");
        Character[2] = GameObject.Find("Character102");
        Character[3] = GameObject.Find("Character103");
        Character[4] = GameObject.Find("Character104");
        Character[5] = GameObject.Find("Character105");
        Character[6] = GameObject.Find("Character106");
        Character[7] = GameObject.Find("Character107");
        Character[8] = GameObject.Find("Character108");
        Character[9] = GameObject.Find("Character109");
        Character[10] = GameObject.Find("Character110");
        Character[11] = GameObject.Find("Character111");
        Character[12] = GameObject.Find("Character112");
        Character[13] = GameObject.Find("Character113");
        Character[14] = GameObject.Find("Character114");
        Character[15] = GameObject.Find("Character115");

        Enemy[0] = GameObject.Find("Enemy100");
        Enemy[1] = GameObject.Find("Enemy101");
        Enemy[2] = GameObject.Find("Enemy102");
        Enemy[3] = GameObject.Find("Enemy103");
        Enemy[4] = GameObject.Find("Enemy104");
        Enemy[5] = GameObject.Find("Enemy105");
        Enemy[6] = GameObject.Find("Enemy106");
        Enemy[7] = GameObject.Find("Enemy107");
        Enemy[8] = GameObject.Find("Enemy108");
        Enemy[9] = GameObject.Find("Enemy109");
        Enemy[10] = GameObject.Find("Enemy110");
        Enemy[11] = GameObject.Find("Enemy111");
        Enemy[12] = GameObject.Find("Enemy112");
        Enemy[13] = GameObject.Find("Enemy113");
        Enemy[14] = GameObject.Find("Enemy114");
        Enemy[15] = GameObject.Find("Enemy115");

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
