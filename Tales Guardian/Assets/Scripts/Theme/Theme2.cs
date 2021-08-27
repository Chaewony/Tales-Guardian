using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Theme2 : MonoBehaviour
{

    public GameObject Theme2UI;
    AudioSource ClickSound;

    private void Start()
    {
        ClickSound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (Theme2UI.activeSelf == false)
        {
            Debug.Log("2번 클릭됨");
            ClickSound.Play();
            //SceneManager.LoadScene("Stage2"); 
        }
    }
}