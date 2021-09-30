using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBGI : MonoBehaviour
{
    public GameObject BGI1;
    public GameObject BGI2;
    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(0,2);
        if(a ==0)
        {
            BGI1.SetActive(true);
            BGI2.SetActive(false);
        }
        if (a == 1)
        {
            BGI1.SetActive(false);
            BGI2.SetActive(true);
        }
    }
}
