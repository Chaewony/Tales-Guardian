using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || timer > 10f)
        {
            SceneManager.LoadScene("Title");
        }
        timer += 1.0f * Time.deltaTime;
    }
}
