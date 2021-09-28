using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || timer > 5.5f)
        {
            SceneManager.LoadScene("Title");
        }
        timer += 1.0f * Time.deltaTime;
    }
}
